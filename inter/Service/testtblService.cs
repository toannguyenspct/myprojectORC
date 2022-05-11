using inter.Interface;
using inter.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inter.Service
{
    public class testtblService : ItesttblService
    {
        private readonly string _connectionString;
        public testtblService(IConfiguration _configuration) {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<testtbl> GetALL() {
            List <testtbl> testtbls = new List<testtbl>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.BindByName = true;
                    cmd.CommandText = "Select MASP,TENSP,SOLUONG FROM TESTTBL";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        testtbl testtbl = new testtbl()
                        {
                            MASP = Convert.ToInt32(rdr["MASP"]),
                            TENSP = rdr["TENSP"].ToString(),
                            SOLUONG = Convert.ToInt32(rdr["SOLUONG"])
                        };
                        testtbls.Add(testtbl);
                    }
                }
            }
            return testtbls;
        }
        public testtbl GetById(int id) {
            testtbl testtbl = new testtbl();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.BindByName = true;
                    cmd.CommandText = "Select MASP,TENSP,SOLUONG FROM TESTTBL Where MASP="+id+"";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        testtbl.MASP = Convert.ToInt32(rdr["MASP"]);
                        testtbl.TENSP = rdr["TENSP"].ToString();
                        testtbl.SOLUONG = Convert.ToInt32(rdr["SOLUONG"]);
                       
                       
                    }
                }
            }
            return testtbl;
        }
        public void Addtesttbl(testtbl tbl)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Insert into TESTTBL(MASP,TENSP,SOLUONG) values(" + tbl.MASP + ",'" + tbl.TENSP + "'," + tbl.SOLUONG + ")";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void Edittesttbl(testtbl tbl)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Update TESTTBL set MASP=" + tbl.MASP + ",TENSP="+tbl.TENSP+",SOLUONG="+tbl.SOLUONG+"where id="+tbl.MASP+"";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void Deletetesttbl(testtbl tbl)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Delete from TESTTBL where MASP="+tbl.MASP+"";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
