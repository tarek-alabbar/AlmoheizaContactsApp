﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AlmoheizaContactsApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AlmoheizaContactsApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new ContactsListViewPage();
            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
