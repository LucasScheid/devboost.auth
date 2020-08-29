using api_dev_boost_auth.Models;
using System.Collections.Generic;

namespace api_dev_boost_auth.Interfaces
{
    public interface INotificador
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
