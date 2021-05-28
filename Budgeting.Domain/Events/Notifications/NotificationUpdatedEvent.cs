using MediatR;
using Budgeting.Domain.Notifications;

namespace Budgeting.Domain.Events.Notifications
{
     public class NotificationUpdatedEvent : INotification
     {
          public NotificationUpdatedEvent(Notification notification)
          {
               Notification = notification;
          }

          public Notification Notification { get; }
     }
}
