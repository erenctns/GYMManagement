using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class PurchaseProduct : Form
    {
        private DataGridView dgvProducts;
        private DataGridView dgvCart;
        private ComboBox cmbMembers;
        private NumericUpDown nudQuantity;
        private Label lblTotalPrice;
        private Button btnAddToCart;
        private Button btnPurchase;

        string connectionString = GlobalVariables.ConnectionString;


        public PurchaseProduct()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadData();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Purchase Product";
            this.Size = new Size(800, 600);

            dgvProducts = new DataGridView { Location = new Point(20, 20), Size = new Size(350, 200), ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            this.Controls.Add(dgvProducts);

            Label lblMembers = new Label { Text = "Select Member:", Location = new Point(20, 230), AutoSize = true };
            this.Controls.Add(lblMembers);

            cmbMembers = new ComboBox { Location = new Point(120, 225), Size = new Size(200, 25) };
            this.Controls.Add(cmbMembers);

            Label lblQuantity = new Label { Text = "Quantity:", Location = new Point(20, 260), AutoSize = true };
            this.Controls.Add(lblQuantity);

            nudQuantity = new NumericUpDown { Location = new Point(120, 255), Size = new Size(100, 25), Minimum = 1, Maximum = 100 };
            this.Controls.Add(nudQuantity);

            btnAddToCart = new Button { Text = "Add to Cart", Location = new Point(240, 255), Size = new Size(100, 30) };
            btnAddToCart.Click += BtnAddToCart_Click;
            this.Controls.Add(btnAddToCart);

            dgvCart = new DataGridView { Location = new Point(400, 20), Size = new Size(350, 200), ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvCart.Columns.Add("ProductID", "Product ID");
            dgvCart.Columns.Add("ProductName", "Product Name");
            dgvCart.Columns.Add("Price", "Price");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("TotalPrice", "Total Price");
            this.Controls.Add(dgvCart);

            lblTotalPrice = new Label { Text = "Total: $0.00", Location = new Point(400, 230), AutoSize = true, Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold) };
            this.Controls.Add(lblTotalPrice);

            btnPurchase = new Button { Text = "Purchase", Location = new Point(400, 260), Size = new Size(100, 30) };
            btnPurchase.Click += BtnPurchase_Click;
            this.Controls.Add(btnPurchase);
        }

        private void LoadData()
        {
            // Load products
            string queryProducts = "SELECT ProductID, ProductName, Price FROM Product";
            DataTable products = ExecuteQuery(queryProducts);
            dgvProducts.DataSource = products;

            // Load members
            string queryMembers = @"
                SELECT 
                    M.MemberID, 
                    (M.FirstName + ' ' + M.LastName) AS FullName,
                    UA.Username 
                FROM Member M
                INNER JOIN UserAuth UA ON M.MemberID = UA.MemberID";
            DataTable members = ExecuteQuery(queryMembers);

            cmbMembers.DataSource = members;
            cmbMembers.DisplayMember = "FullName";
            cmbMembers.ValueMember = "MemberID";
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Check ProductID
                object productIdObj = dgvProducts.SelectedRows[0].Cells["ProductID"].Value;

                if (productIdObj == null || Convert.ToInt32(productIdObj) == 0)
                {
                    MessageBox.Show("Invalid ProductID. Please select a valid product.");
                    return;
                }

                int productId = Convert.ToInt32(productIdObj);
                string productName = dgvProducts.SelectedRows[0].Cells["ProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(dgvProducts.SelectedRows[0].Cells["Price"].Value);
                int quantity = Convert.ToInt32(nudQuantity.Value);
                decimal totalPrice = price * quantity;

                dgvCart.Rows.Add(productId, productName, price, quantity, totalPrice);
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
            }
            lblTotalPrice.Text = $"Total: {total:C}";
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            if (cmbMembers.SelectedValue == null || dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Please select a member and add products to the cart.");
                return;
            }

            int memberId = Convert.ToInt32(cmbMembers.SelectedValue);
            DateTime purchaseDate = DateTime.Now;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                string checkProductQuery = "SELECT COUNT(*) FROM Product WHERE ProductID = @ProductID";
                int productExists = Convert.ToInt32(ExecuteScalar(checkProductQuery, new SqlParameter("@ProductID", productId)));

                if (productExists == 0)
                {
                    MessageBox.Show("Purchase completed successfully!");
                    continue;
                }

                // Purchase operation
                string insertPurchaseQuery = @"INSERT INTO Purchase (MemberID, ProductID, Quantity, PurchaseDate)
                                               VALUES (@MemberID, @ProductID, @Quantity, @PurchaseDate)";
                ExecuteNonQuery(insertPurchaseQuery,
                    new SqlParameter("@MemberID", memberId),
                    new SqlParameter("@ProductID", productId),
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@PurchaseDate", purchaseDate));

                // Update stock
                string updateStockQuery = "UPDATE Product SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                ExecuteNonQuery(updateStockQuery,
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@ProductID", productId));
            }

            dgvCart.Rows.Clear();
            UpdateTotalPrice();
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
