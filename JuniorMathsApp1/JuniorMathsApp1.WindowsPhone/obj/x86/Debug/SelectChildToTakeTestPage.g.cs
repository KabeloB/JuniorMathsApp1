﻿

#pragma checksum "D:\Mod\Documents\Visual Studio 2013\Projects\JuniorMathsApp1\JuniorMathsApp1\JuniorMathsApp1.WindowsPhone\SelectChildToTakeTestPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45855BD78D14B50ED1A8C0B5B7E5AB9B"
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
    partial class SelectChildToTakeTestPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 15 "..\..\..\SelectChildToTakeTestPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSelect_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 16 "..\..\..\SelectChildToTakeTestPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnBack_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 17 "..\..\..\SelectChildToTakeTestPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.MySelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


