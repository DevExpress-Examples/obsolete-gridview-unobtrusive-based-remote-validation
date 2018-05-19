Imports System.Web.Mvc
Imports System.ComponentModel.DataAnnotations

Public Class Product
	Public Property ProductID() As Integer
	<Required(ErrorMessage := "Product Name is required"), Remote("CheckIfExists", "Home", AdditionalFields := "OriginalProductName", ErrorMessage := "The name you specified already exists. Please specify a different name.")>
	Public Property ProductName() As String
	Public Property UnitPrice() As Decimal?
	Public Property UnitsOnOrder() As Short?
End Class