﻿

#pragma checksum "D:\Mod\Source\Repos\JuniorMathsApp1\JuniorMathsApp1\JuniorMathsApp1.WindowsPhone\ViewAllResultsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0E25BD1F4E1C82D51D9D0AB8537E4259"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JuniorMathsApp1
{
    partial class ViewAllResultsPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 18 "..\..\..\ViewAllResultsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnBack_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 19 "..\..\..\ViewAllResultsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnReturnMainMenu_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 20 "..\..\..\ViewAllResultsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.lsViewTest_itemClicked;
                 #line default
                 #line hidden
                #line 20 "..\..\..\ViewAllResultsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.lsViewTest_selectionChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 40 "..\..\..\ViewAllResultsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnDeleteAll_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


