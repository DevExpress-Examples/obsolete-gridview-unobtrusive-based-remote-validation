@ModelType List(Of Product)

@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "GridView"
            settings.KeyFieldName = "ProductID"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
            settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewAddNewPartial"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewUpdatePartial"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewDeletePartial"}

            settings.SettingsEditing.ShowModelErrorsForEditors = True
    
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowEditButton = True
            settings.CommandColumn.ShowNewButton = True
            settings.CommandColumn.ShowDeleteButton = True

            settings.Columns.Add( _
                Sub(column)
                        column.FieldName = "ProductID"
                        column.ReadOnly = True
                        column.EditFormSettings.Visible = DefaultBoolean.False
                End Sub)

            settings.Columns.Add("ProductName")
            settings.Columns.Add("UnitPrice")
            settings.Columns.Add("UnitsOnOrder")

            settings.SetEditFormTemplateContent( _
                Sub(container)
                        Dim editableProduct As New Product
                        
                        If Not container.Grid.IsNewRowEditing Then
                            editableProduct = Model.FirstOrDefault(Function(m As Product) m.ProductID = Convert.ToInt32(DataBinder.Eval(container.DataItem, "ProductID")))
                        End If
                        
                        Html.RenderPartial("EditFormPartial", editableProduct)
                End Sub)
    End Sub).SetEditErrorText(CType(ViewData("EditError"), String)).Bind(Model).GetHtml()
