Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports DevExpress.Web.Mvc
Imports SchedulerSimpleCustomFormMvc.Models
Imports DevExpress.Web.ASPxScheduler

Namespace SchedulerSimpleCustomFormMvc.Code
    Public Module SchedulerHelper
        Private settings_Renamed As SchedulerSettings

        Public ReadOnly Property Settings() As SchedulerSettings
            Get
                If settings_Renamed Is Nothing Then
                    settings_Renamed = CreateSchedulerSettings(Nothing)
                End If
                Return settings_Renamed
            End Get
        End Property

        <System.Runtime.CompilerServices.Extension> _
        Public Function CreateSchedulerSettings(ByVal htmlHelper As HtmlHelper) As SchedulerSettings
            Dim settings As New SchedulerSettings()
            settings.Name = "scheduler"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SchedulerPartial"}
            settings.EditAppointmentRouteValues = New With {Key .Controller = "Home", Key .Action = "EditAppointment"}

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage)
            settings.Storage.Resources.Assign(DefaultResourceStorage)

            settings.AppointmentFormShowing = Function(sender, e) AnonymousMethod1(sender, e)

            settings.OptionsForms.SetAppointmentFormTemplateContent(Function(c) AnonymousMethod2(c, htmlHelper))

            settings.Storage.Appointments.ResourceSharing = True
            settings.Start = New DateTime(2008, 7, 11)
            Return settings
        End Function

        Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As AppointmentFormEventArgs) As Boolean
            Dim scheduler As MVCxScheduler = TryCast(sender, MVCxScheduler)
            If scheduler IsNot Nothing Then
                e.Container = New CustomAppointmentFormTemplateContainer(scheduler)
            End If
            Return True
        End Function

        Private Function AnonymousMethod2(ByVal c As Object, ByVal htmlHelper As HtmlHelper) As Boolean
            Dim container As CustomAppointmentFormTemplateContainer = CType(c, CustomAppointmentFormTemplateContainer)
            Dim schedule As New ValidationSchedule() With {.ID = If(container.Appointment.Id Is Nothing, -1, CInt(Fix(container.Appointment.Id))), .Subject = container.Appointment.Subject, .StartTime = container.Appointment.Start, .EndTime = container.Appointment.End, .Price = container.Price}
            htmlHelper.ViewData("DeleteButtonEnabled") = container.CanDeleteAppointment
            htmlHelper.RenderPartial("CustomAppointmentFormPartial", schedule)
            Return True
        End Function

        Private defaultAppointmentStorage_Renamed As MVCxAppointmentStorage
        Public ReadOnly Property DefaultAppointmentStorage() As MVCxAppointmentStorage
            Get
                If defaultAppointmentStorage_Renamed Is Nothing Then
                    defaultAppointmentStorage_Renamed = CreateDefaultAppointmentStorage()
                End If
                Return defaultAppointmentStorage_Renamed
            End Get
        End Property
        Private Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
            Dim appointmentStorage As New MVCxAppointmentStorage()
            appointmentStorage.Mappings.AppointmentId = "ID"
            appointmentStorage.Mappings.Start = "StartTime"
            appointmentStorage.Mappings.End = "EndTime"
            appointmentStorage.Mappings.Subject = "Subject"
            appointmentStorage.Mappings.Description = "Description"
            appointmentStorage.Mappings.Location = "Location"
            appointmentStorage.Mappings.AllDay = "AllDay"
            appointmentStorage.Mappings.Type = "EventType"
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo"
            appointmentStorage.Mappings.Label = "Label"
            appointmentStorage.Mappings.Status = "Status"
            appointmentStorage.Mappings.ResourceId = "CarId"
            appointmentStorage.CustomFieldMappings.Add("Price", "Price")
            Return appointmentStorage
        End Function

        Private defaultResourceStorage_Renamed As MVCxResourceStorage
        Public ReadOnly Property DefaultResourceStorage() As MVCxResourceStorage
            Get
                If defaultResourceStorage_Renamed Is Nothing Then
                    defaultResourceStorage_Renamed = CreateDefaultResourceStorage()
                End If
                Return defaultResourceStorage_Renamed
            End Get
        End Property
        Private Function CreateDefaultResourceStorage() As MVCxResourceStorage
            Dim resourceStorage As New MVCxResourceStorage()
            resourceStorage.Mappings.ResourceId = "ID"
            resourceStorage.Mappings.Caption = "Model"
            Return resourceStorage
        End Function
    End Module
End Namespace