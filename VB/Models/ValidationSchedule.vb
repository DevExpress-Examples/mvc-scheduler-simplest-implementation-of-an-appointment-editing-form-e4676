Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel.DataAnnotations

Namespace SchedulerSimpleCustomFormMvc.Models
	Public Class ValidationSchedule
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateSubject As String
		<Required(ErrorMessage := "The Subject must contain at least one character.")> _
		Public Property Subject() As String
			Get
				Return privateSubject
			End Get
			Set(ByVal value As String)
				privateSubject = value
			End Set
		End Property
		Private privatePrice? As Decimal
		Public Property Price() As Decimal?
			Get
				Return privatePrice
			End Get
			Set(ByVal value? As Decimal)
				privatePrice = value
			End Set
		End Property
		Private privateStartTime As DateTime
		<Required> _
		Public Property StartTime() As DateTime
			Get
				Return privateStartTime
			End Get
			Set(ByVal value As DateTime)
				privateStartTime = value
			End Set
		End Property
		Private privateEndTime As DateTime
		<Required> _
		Public Property EndTime() As DateTime
			Get
				Return privateEndTime
			End Get
			Set(ByVal value As DateTime)
				privateEndTime = value
			End Set
		End Property
	End Class
End Namespace