﻿

#pragma checksum "D:\Mod\Source\Repos\JuniorMathsApp1\JuniorMathsApp1\JuniorMathsApp1.Windows\SelectChildToViewPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7700F71DF2BEDEAF55D77977F5F4E1AB"
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
    partial class SelectChildToViewPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.MySelectionChanged;
                 #line default
                 #line hidden
                #line 14 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.lsViewChildren_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 16 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnView_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 17 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnBack_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 18 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnDeleteChild_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 19 "..\..\..\SelectChildToViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnEditChildDetails_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


