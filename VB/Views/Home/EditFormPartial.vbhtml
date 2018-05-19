@ModelType Product

@Using (Html.BeginForm("Index", "Home", FormMethod.Post, New With {Key .id = "frmProduct"}))
    @Html.Hidden("OriginalProductName", Model.ProductName)
    @<table>
        <tr>
            <td>
                @Html.DevExpress().Label( _
                    Sub(s)
                        s.AssociatedControlName = "ProductName"
                        s.Text = "Product Name:"
                    End Sub).GetHtml()
            </td>
            <td>
                @Html.DevExpress().TextBox( _
                    Sub(s)
                        s.Name = "ProductName"
                        s.ShowModelErrors = True
                End Sub).Bind(Model.ProductName).GetHtml()
            </td>
        </tr>
        <tr>
            <td>
                @Html.DevExpress().Label( _
                    Sub(s)
                        s.AssociatedControlName = "UnitPrice"
                        s.Text = "Unit Price:"
                    End Sub).GetHtml()
            </td>
            <td>
                @Html.DevExpress().TextBox( _
                    Sub(s)
                        s.Name = "UnitPrice"
                        s.ShowModelErrors = True
                    End Sub).Bind(Model.UnitPrice).GetHtml()
            </td>
        </tr>
        <tr>
            <td>
                @Html.DevExpress().Label( _
                    Sub(s)
                        s.AssociatedControlName = "UnitsOnOrder"
                        s.Text = "Units On Order:"
                    End Sub).GetHtml()
            </td>
            <td>
                @Html.DevExpress().TextBox( _
                    Sub(s)
                        s.Name = "UnitsOnOrder"
                        s.ShowModelErrors = True
                    End Sub).Bind(Model.UnitsOnOrder).GetHtml()
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                @Html.DevExpress().HyperLink( _
                    Sub(s)
                        s.Name = "Update"
                        s.Properties.Text = "Update"
                        s.NavigateUrl = "javascript:UpdateGridView();"
                    End Sub).GetHtml()
                @Html.DevExpress().HyperLink( _
                    Sub(s)
                        s.Name = "Cancel"
                        s.Properties.Text = "Cancel"
                        s.NavigateUrl = "javascript:GridView.CancelEdit();"
                    End Sub).GetHtml()
            </td>
        </tr>
    </table>
End Using