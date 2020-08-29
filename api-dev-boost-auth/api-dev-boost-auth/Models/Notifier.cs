using api_dev_boost_auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_dev_boost_auth.Models
{
    public class Notifier : INotificador
    {
        private List<Notification> _notificacoes;

        public Notifier()
        {
            _notificacoes = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HaveNotification()
        {
            return _notificacoes.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notificacoes;
        }

    }
}
