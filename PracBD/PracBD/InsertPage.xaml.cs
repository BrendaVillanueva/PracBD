using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PracBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        SQLiteConnection database;
        public InsertPage()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("PractMD.db");
            database = new SQLiteConnection(db);
        }

        private void Button_Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Matricula= Convert.ToInt32(Entry_Matricula.Text),
                Nombre= Entry_Nombre.Text,
                Apellido=Entry_Apellido.Text,
                Direccion= Entry_Direccion.Text,
                Telefono= Convert.ToInt32(Entry_Telefono.Text),
                Carrera= Entry_Carrera.Text,
                Semestre= Entry_Semestre.Text,
                Correo= Entry_Correo.Text,
                GitHub= Entry_GitHub.Text

            };
            database.Insert(datos);
            Navigation.PushAsync(new DataPage());

        }
    }
}