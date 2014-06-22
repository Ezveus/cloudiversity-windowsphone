using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClouDiversity
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();

           /* ListBox listBox1 = new ListBox();
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");
            listBox1.Width = 140;
            //listBox1.SelectionChanged += ListBox_SelectionChanged;
            */
            // Add the list box to a parent container in the visual tree.
            listBox1.Items.Add("Mercredi 25 juin");
            listBox1.Items.Add("    Math 301 - Equation");
            listBox1.Items.Add("    Histoire 308 - Gangs of NY review");

            listBox1.Items.Add("  ");

            listBox1.Items.Add("Jeudi 26 juin");
            listBox1.Items.Add("    Francais 301 - Redaction");
            listBox1.Items.Add("    Chimie 308 - Jouer avec le feu (poum)");

        }
    }
}