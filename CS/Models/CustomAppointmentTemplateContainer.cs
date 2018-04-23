using System;
using DevExpress.Web.Mvc;
using DevExpress.Web.ASPxScheduler;

namespace SchedulerSimpleCustomFormMvc.Models {
    public class CustomAppointmentFormTemplateContainer : AppointmentFormTemplateContainer {
        public CustomAppointmentFormTemplateContainer(MVCxScheduler scheduler)
            : base(scheduler) {
        }
        public decimal? Price {
            get {
                object price = Appointment.CustomFields["Price"];
                return price == DBNull.Value ? 0 : (decimal?)price;
            }
        }
    }
}