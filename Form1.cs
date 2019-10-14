using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Gmail_latter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            // подключим sntp
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);

            // логинимся
            smtp.Credentials = new NetworkCredential("abdulhack1m@yandex.ru", "logo-dop-room-Ref-990");

            // используется шифрование 
            smtp.EnableSsl = true;
            // сформулируем письмо
            MailMessage message = new MailMessage();

            // от кого письмо
            message.From = new MailAddress("abdulhack1m@yandex.ru", "Учимся отправлять рассылки");

            // кому письмо
            message.To.Add(new MailAddress("komok113@yandex.ru"));

            // когда нужна ссылка на "Ответить" в сервисе то пишем
            message.ReplyToList.Add("abdulhack1m@yandex.ru");

            // формулируем тело писма
            // заголовок
            message.Subject = textBox1.Text;

            // формулируем тело письма
            // теперь перетащим данные Элемента на форму "richTextBox1"
            // проверяем на пустоту 
            if (richTextBox1.Text != "" || textBox1.Text !="")
            {
                message.Body = richTextBox1.Text;
            }
            // устанавливаем приоритет
            message.Priority = MailPriority.Normal;

            // пусть письмо будет в формате HTML
            message.IsBodyHtml = true;
            // устанавливаем кодировку письма
            message.BodyEncoding = Encoding.UTF8;

            // давайте отправим сообщение 
            try
            {
                // если все нормуль, то будет выполнена отсылка, кстати этот вариант синхронной отсылки
                // давайте введём проверку письма, чтобы пустое поле не отправлять
                if (richTextBox1.Text != "")
                {
                    smtp.Send(message);
                    // закроем
                    message.Dispose();
                    label2.Text = "Сообщене отправлено";
                }
                else
                {
                    label2.Text = "Нет данных!";
                }
                // добавляем информатор


            }
            catch (Exception ex) { throw new Exception(ex.Message); };
        }
    }
}
