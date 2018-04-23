# MVC Scheduler: Simplest implementation of an appointment editing form


<p>This example illustrates the simplest possible implementation of custom appointment editing form. This form in our example is defined in the <strong>~/Home/CustomAppointmentFormPartial.cshtml</strong> view and has only several fields:</p><p></p><p>- Subject, Start, and End regular attributes;</p><p>- Price custom field,</p><p></p><p>Other features are skipped/disabled for the sake of clarity.</p><p></p><p>Here are some important points concerning the implementation:</p><p></p><p>a) We use the <strong>SchedulerHelper </strong>class to initialize Scheduler settings for its view. This class has the following extension method that allows you to utilize it in the view's code:</p><p></p>

```cs
public static SchedulerSettings CreateSchedulerSettings(this HtmlHelper htmlHelper)
```

<p></p><p>Note that the <strong>RenderPartial()</strong> and <strong>ViewData </strong>members of an <a href="http://msdn.microsoft.com/en-us/library/system.web.mvc.htmlhelper(v=vs.108).aspx">HtmlHelper Class</a> instance are used to render a custom form and pass parameters to it respectively.</p><p></p><p>b) Scheduler settings are passed to <strong>SchedulerExtension.GetAppointmentTo*()</strong> methods according to the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11629">Lesson 3 - Use Scheduler in Complex Views</a> help section.</p><p></p><p>c) As usual, the Scheduler is rendered in a separate partial view. Refer to the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052">ASP.NET MVC Extensions > Common Concepts > Using Callbacks</a> help section to see why it is important.</p><p></p><p><strong>See Also:</strong></p><p><a href="http://demos.devexpress.com/MVC/Scheduler/CustomForms">Scheduler - Custom Forms</a></p><p><a href="https://www.devexpress.com/Support/Center/p/E4520">Scheduler - How to implement a custom Edit Appointment Form with custom fields</a></p>

<br/>


