﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace RestManag
{
    public partial class Login : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da,da1;
        private DataTable dt,dt1;
        
        
 


        public Login()
        {
            InitializeComponent();
        }

      

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Rest;Integrated Security=True;Pooling=False");
             cmd = new SqlCommand("Select Count(*) FROM Rest where username='" + textBox1.Text + "' and password ='" + textBox2.Text + "'" + " and ISAdmin=1",con);
             da1 = new SqlDataAdapter(cmd);
             dt1 = new DataTable();
             da1.Fill(dt1);

            da = new SqlDataAdapter("Select Count(*) FROM Rest where username='" + textBox1.Text + "' and password ='" + textBox2.Text + "'" + " and ISAdmin=0",con);
            dt = new DataTable();
            da.Fill(dt);
           
            if (dt.Rows[0][0].ToString() == "1")
            { 
                Waiter w = new Waiter(); // This is bad
                w.Show();
                
            }
            else if(dt1.Rows[0][0].ToString()== "1"){
                this.Hide();
                Admin a = new Admin();
                a.Show();
            }else
            {
                MessageBox.Show("please check you username and password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
