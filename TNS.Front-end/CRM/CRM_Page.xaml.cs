﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TNS.Front_end.Utils;

namespace TNS.Front_end.CRM;

/// <summary>
/// Логика взаимодействия для CRM.xaml
/// </summary>
public partial class CRM_Page : Page
{
    List<string> services = [];
    List<CRM_request> members =
    [
        new CRM_request { Id = "id" , NumberRequest = "number", AbonentNumber = "8989898989", Service = "Интернет", Status = "Открыта", TypeEquipment = "УАЗ-21" },
        new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Телевидение", Status = "Закарыта", TypeEquipment = "УАЗ-21" },
        new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Мобильная связь", Status = "Открыта", TypeEquipment = "УАЗ-21" },
        new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Интернет", Status = "Закрыта", TypeEquipment = "УАЗ-21" },
       
    ];

    List<CRM_request> membersCopy;
    List<CRM_request> membersChanged;

    public CRM_Page()
    {
        InitializeComponent();
        membersCopy = new(members);
        membersDataGrid.ItemsSource = members;
    }

    private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void StatusBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void TypeEquipmentBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddButton(object sender, RoutedEventArgs e)
    {

    }

    private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void Open_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
    {

    }

    private void ServicesBtn_Click(object sender, RoutedEventArgs e)
    {

    }
}