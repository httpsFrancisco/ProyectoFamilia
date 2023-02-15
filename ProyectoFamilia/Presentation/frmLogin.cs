﻿using ProyectoFamilia.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFamilia.Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SqlConnection c = ConexionSql.conexion();
            SqlCommand comand = new SqlCommand("SELECT * FROM Login WHERE usuario=@usuario AND password =@password", c);
            comand.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            comand.Parameters.AddWithValue("@password", txtPassword.Text);

            c.Open();
            SqlDataReader reader = comand.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Ingresando al Sistema", "Titutlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMenuPrincipal MenuPrincipal =  new frmMenuPrincipal();
                MenuPrincipal.Show();

            }
            else
            {
                MessageBox.Show("El Usuario o Contraseña es incorrecto, porfavor Intente nuevamente", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            c.Close();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "INGRESE USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "INGRESE USUARIO";
                txtUsuario.ForeColor = Color.Silver;
            }
        }
    }
}
