using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Builder {
    class EmailBuilder {
        public TopicBuilder addTopic(string t) {
            return new TopicBuilder(t);
        }

        public class TopicBuilder {
            string topic;

            public TopicBuilder(string t) { topic=t; }

            public BodyBuilder addBody(string b) {
                return new BodyBuilder(topic, b);
            }
            
            public EmailProduct getRes() {   
                return new EmailProduct(topic);
            } //завершения конструирования 1ой части письма (темы)
        }
        public class BodyBuilder {
            string topic, body;

            public BodyBuilder(string t = null, string b = null) { topic=t; body=b; }

            public RecipientsBuilder addRecipients(List<string> rs) {
                new EmailProduct(topic, body, rs);
                return new RecipientsBuilder(topic, body, rs);
            }

            public EmailProduct getRes() {  
                return new EmailProduct(topic, body);
            } //завершения конструирования 2ой части письма (текста)
        }
        public class RecipientsBuilder {
            string topic, body;

            List<string> r = new List<string>();

            public RecipientsBuilder(string t = null, string b = null, List<string> rs = null) { topic=t; body=b; r.AddRange(rs); }

            public EmailProduct getRes() {      
                return new EmailProduct(topic, body, r);
            } //завершения конструирования всего письма 
        }
    }
}
