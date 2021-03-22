using BozaPodroz.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BozaPodroz
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        Post selectedPost;
        public PostDetail(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceLabel.Text = selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceLabel.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Sukces", "Zaktualizowano pomyślnie", "Ok");
                }
                else DisplayAlert("Niepowodzenie", "Nie zaktualizowano pomyślnie", "Ok");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Sukces", "Usunięto pomyślnie", "Ok");
                }
                else DisplayAlert("Niepowodzenie", "Nie usunięto pomyślnie", "Ok");
            }
        }
    }
}