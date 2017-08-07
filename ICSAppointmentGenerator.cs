//Creates an ICS meeting, making the first 2 users mandatory and 3rd optional attendance.

System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
m.From = new Net.Mail.MailAddress("sender@xyz.com");
m.To.Add(new Net.Mail.MailAddress("xxx@xyz.com", "xxxName Here"));
m.To.Add(new Net.Mail.MailAddress("yyy@xyz.com", "yyyName Here"));
m.To.Add(new Net.Mail.MailAddress("zzz@xyz.com", "zzzName Here"));
m.Subject = "TEST APPOINTMENT - PROGRAMATICALLY GENERATED";
m.Body = "This appointment was automatically generated on " + DateTime.Now.ToLongDateString();
m.Headers.Add("Content-class", "urn:content-classes:calendarmessage");

StringBuilder s = new StringBuilder();
s.AppendLine("BEGIN:VCALENDAR");
s.AppendLine("PRODID:-//Schedule a Meeting");
s.AppendLine("VERSION:2.0");
s.AppendLine("METHOD:REQUEST");
s.AppendLine("BEGIN:VEVENT");
s.AppendLine(string.Format("LOCATION:{0}", "IT Breakout Room"));
s.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddMinutes(+330)));
s.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
s.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddMinutes(+360)));
s.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
s.AppendLine(string.Format("DESCRIPTION:{0}", m.Body));
s.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", m.Body));
s.AppendLine(string.Format("SUMMARY:{0}", m.Subject));
s.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", m.From.Address));
for (int i = 0; i <= m.To.Count - 1; i++) {
  s.AppendLine(string.Format("ATTENDEE;CN="{0}";" + ((i == 2) ? "ROLE=OPT-PARTICIPANT;" : "") + "RSVP=TRUE:mailto:{1}", m.To(i).DisplayName, m.To(i).Address))
}
s.AppendLine("BEGIN:VALARM");
s.AppendLine("TRIGGER:-PT15M");
s.AppendLine("ACTION:DISPLAY");
s.AppendLine("DESCRIPTION:Reminder");
s.AppendLine("END:VALARM");
s.AppendLine("END:VEVENT");
s.AppendLine("END:VCALENDAR");

System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient();
smtpclient.Host = "<<Your Server Here>>";

smtpclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
contype.Parameters.Add("method", "REQUEST");
contype.Parameters.Add("name", "Meeting.ics");
System.Net.Mail.AlternateView avCal = System.Net.Mail.AlternateView.CreateAlternateViewFromString(s.ToString(), contype);
m.AlternateViews.Add(avCal);
smtpclient.Send(m);

