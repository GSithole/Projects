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
        public IEnumerable<Cart> getProdFromCart(string userId, int prodid)
        {

            string connectionString =
            ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;
            List<Cart> carts = new List<Cart>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetFromCart", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@userId";
                paramUserId.Value = userId;
                cmd.Parameters.Add(paramUserId);

                SqlParameter paramProdid = new SqlParameter();
                paramProdid.ParameterName = "@prodid";
                paramProdid.Value = prodid;
                cmd.Parameters.Add(paramProdid);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cart cart = new Cart();
                    cart.userId = rdr["userid"].ToString();
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

        public IEnumerable<Cart> getProdFromCartForUser(string userId)
        {

            string connectionString =
            ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;
            List<Cart> carts = new List<Cart>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCartForUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@userid";
                paramUserId.Value = userId;
                cmd.Parameters.Add(paramUserId);
                              
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cart cart = new Cart();
                    cart.userId = rdr["userid"].ToString();
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

        public void EditCart(string userid,int prodid,int qty, double total)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spEditCart", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@userId";
                paramUserId.Value = userid;
                cmd.Parameters.Add(paramUserId);

               
                SqlParameter paramProdId = new SqlParameter();
                paramProdId.ParameterName = "@prodid";
                paramProdId.Value = prodid;
                cmd.Parameters.Add(paramProdId);

                SqlParameter paramqty = new SqlParameter();
                paramqty.ParameterName = "@pqty";
                paramqty.Value = qty;
                cmd.Parameters.Add(paramqty);

                SqlParameter paramTotal = new SqlParameter();
                paramTotal.ParameterName = "@total";
                paramTotal.Value = total;
                cmd.Parameters.Add(paramTotal);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddToCart(Cart cart)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddToCart", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@userId";
                paramUserId.Value = cart.userId;
                cmd.Parameters.Add(paramUserId);

                SqlParameter paramProdId = new SqlParameter();
                paramProdId.ParameterName = "@prodid";
                paramProdId.Value = cart.ProdID;
                cmd.Parameters.Add(paramProdId);

                SqlParameter paramProdName = new SqlParameter();
                paramProdName.ParameterName = "@prodName";
                paramProdName.Value = cart.ProdName;
                cmd.Parameters.Add(paramProdName);

                SqlParameter paramImageUrl = new SqlParameter();
                paramImageUrl.ParameterName = "@ImageUrl";
                paramImageUrl.Value = cart.ImageUrl;
                cmd.Parameters.Add(paramImageUrl);

                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@price";
                paramPrice.Value = cart.EachPrice;
                cmd.Parameters.Add(paramPrice);

                SqlParameter paramqty = new SqlParameter();
                paramqty.ParameterName = "@qnty";
                paramqty.Value = cart.Quantity;
                cmd.Parameters.Add(paramqty);

                //int tot = (int)(Convert.ToInt32(cart.EachPrice) * cart.Quantity);

                SqlParameter paramTotal = new SqlParameter();
                paramTotal.ParameterName = "@total";
                paramTotal.Value = cart.Total;
                cmd.Parameters.Add(paramTotal);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCart(int id, string userid)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["DBase"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCart", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramProdId = new SqlParameter();
                paramProdId.ParameterName = "@prodid";
                paramProdId.Value = id;
                cmd.Parameters.Add(paramProdId);

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@userId";
                paramUserId.Value = userid;
                cmd.Parameters.Add(paramUserId);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
