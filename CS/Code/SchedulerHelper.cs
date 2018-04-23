using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DevExpress.Web.Mvc;
using SchedulerSimpleCustomFormMvc.Models;

namespace SchedulerSimpleCustomFormMvc.Code {
    public static class SchedulerHelper {
        static SchedulerSettings settings;

        public static SchedulerSettings Settings {
            get {
                if (settings == null)
                    settings = CreateSchedulerSettings(null);
                return settings;
            }
        }

        public static SchedulerSettings CreateSchedulerSettings(this HtmlHelper htmlHelper) {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SchedulerPartial" };
            settings.EditAppointmentRouteValues = new { Controller = "Home", Action = "EditAppointment" };

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(DefaultResourceStorage);

            settings.AppointmentFormShowing = (sender, e) => {
                MVCxScheduler scheduler = sender as MVCxScheduler;
                if (scheduler != null)
                    e.Container = new CustomAppointmentFormTemplateContainer(scheduler);
            };

            settings.OptionsForms.SetAppointmentFormTemplateContent(c => {
                CustomAppointmentFormTemplateContainer container = (CustomAppointmentFormTemplateContainer)c;
                ValidationSchedule schedule = new ValidationSchedule() {
                    ID = container.Appointment.Id == null ? -1 : (int)container.Appointment.Id,
                    Subject = container.Appointment.Subject,
                    StartTime = container.Appointment.Start,
                    EndTime = container.Appointment.End,
                    Price = container.Price,
                };

                htmlHelper.ViewData["DeleteButtonEnabled"] = container.CanDeleteAppointment;

                htmlHelper.RenderPartial("CustomAppointmentFormPartial", schedule);
            });

            settings.Storage.Appointments.ResourceSharing = true;
            settings.Start = new DateTime(2008, 7, 11);
            return settings;
        }

        static MVCxAppointmentStorage defaultAppointmentStorage;
        public static MVCxAppointmentStorage DefaultAppointmentStorage {
            get {
                if (defaultAppointmentStorage == null)
                    defaultAppointmentStorage = CreateDefaultAppointmentStorage();
                return defaultAppointmentStorage;
            }
        }
        static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            appointmentStorage.Mappings.AppointmentId = "ID";
            appointmentStorage.Mappings.Start = "StartTime";
            appointmentStorage.Mappings.End = "EndTime";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Type = "EventType";
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "CarId";
            appointmentStorage.CustomFieldMappings.Add("Price", "Price");
            return appointmentStorage;
        }

        static MVCxResourceStorage defaultResourceStorage;
        public static MVCxResourceStorage DefaultResourceStorage {
            get {
                if (defaultResourceStorage == null)
                    defaultResourceStorage = CreateDefaultResourceStorage();
                return defaultResourceStorage;
            }
        }
        static MVCxResourceStorage CreateDefaultResourceStorage() {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
            resourceStorage.Mappings.ResourceId = "ID";
            resourceStorage.Mappings.Caption = "Model";
            return resourceStorage;
        }
    }
}