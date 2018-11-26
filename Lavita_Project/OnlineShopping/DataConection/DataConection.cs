using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataConection
{
    public partial class DataConection
    {
        public IEnumerable<Product> GetProducts
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

                List<Product> products = new List<Product>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllProducts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product product = new Product();
                        product.ProdID = Convert.ToInt32(rdr["ID"]);
                        product.ProdName = rdr["ProdName"].ToString();
                        product.ImageUrl = rdr["ImageUrl"].ToString();
                        product.Price = Convert.ToDouble(rdr["Price"]);

                        products.Add(product);
                    }
                }
                return products;
            }
        }

        public IEnumerable<User> GetUser(string username, string passwrd)
        {
            
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;
                List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userName = new SqlParameter();
                userName.ParameterName = "@userName";
                userName.Value = username;
                cmd.Parameters.Add(userName);

                SqlParameter paramPasswrd = new SqlParameter();
                paramPasswrd.ParameterName = "@passwrd";
                paramPasswrd.Value = passwrd;
                cmd.Parameters.Add(paramPasswrd);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    User user = new User();
                    user.userid = Convert.ToInt32(rdr["userid"]);
                    user.userName = rdr["userName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.password = rdr["passwrd"].ToString();
                    users.Add(user);
                }                         
                
            }
            return users;

        }

        public IEnumerable<User> ValidateUser(string username, string email)
        {

            string connectionString =
            ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userName = new SqlParameter();
                userName.ParameterName = "@userName";
                userName.Value = username;
                cmd.Parameters.Add(userName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = email;
                cmd.Parameters.Add(paramEmail);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    User user = new User();
                    user.userid = Convert.ToInt32(rdr["userid"]);
                    user.userName = rdr["userName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.password = rdr["passwrd"].ToString();
                    users.Add(user);
                }

            }
            return users;

        }

        public void AddUser(User user)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userName = new SqlParameter();
                userName.ParameterName = "@userName";
                userName.Value = user.userName;
                cmd.Parameters.Add(userName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = user.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramPasswrd = new SqlParameter();
                paramPasswrd.ParameterName = "@passwrd";
                paramPasswrd.Value = user.password;
                cmd.Parameters.Add(paramPasswrd);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Cart> GetCarts
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

                List<Cart> carts = new List<Cart>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetFromCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Cart cart = new Cart();
                        cart.userId = rdr["userId"].ToString();
                        cart.ProdID = Convert.ToInt32(rdr["ProdID"]);
                        cart.ProdName = rdr["ProdName"].ToString();
                        cart.ImageUrl = rdr["ImageUrl"].ToString();
                        cart.EachPrice = Convert.ToDouble(rdr["EachPrice"]);
                        cart.Quantity = Convert.ToInt32(rdr["Quantity"]);
                        cart.Total = Convert.ToDouble(rdr["Total"]);

                        carts.Add(cart);
                    }
                }
                return carts;
            }
        }
    }
}
