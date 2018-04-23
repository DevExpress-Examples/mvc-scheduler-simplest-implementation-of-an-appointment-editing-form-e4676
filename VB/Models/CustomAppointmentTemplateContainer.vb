Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxScheduler

Namespace SchedulerSimpleCustomFormMvc.Models
	Public Class CustomAppointmentFormTemplateContainer
		Inherits AppointmentFormTemplateContainer
		Public Sub New(ByVal scheduler As MVCxScheduler)
			MyBase.New(scheduler)
		End Sub
		Public ReadOnly Property Price() As Decimal?
			Get
'INSTANT VB NOTE: The local variable price was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim price_Renamed As Object = Appointment.CustomFields("Price")
				Return If(price_Renamed Is DBNull.Value, 0, CType(price_Renamed, Decimal?))
			End Get
		End Property
	End Class
End Namespace