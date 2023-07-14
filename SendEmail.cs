//made by mrphilipjoel#0074 on Discord. May 23, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using System.Net.Mail;
using System;
using System.Net;

public class SendEmail : FsmStateAction
{
    public FsmString fromName;
    public FsmString senderEmail;
    public FsmString senderPassword;
    public FsmString recipientEmail;
    public FsmString subject;
    [HutongGames.PlayMaker.Tooltip("Use '<br />' for a new line")]
    public FsmString body;
    public FsmString smtpClient;

    public override void Reset()
    {
        fromName = "Your Name";
        senderEmail = null;
        senderPassword = null;
        recipientEmail = null;
        subject = null;
        body = null;
        smtpClient = "smtp.gmail.com";
    }

    public override void OnEnter()
    {
        SendTheEmail();
    }

    private void SendTheEmail()
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            mail.IsBodyHtml = true;
            // Set the sender's email address, password, and display name
            mail.From = new MailAddress(senderEmail.Value, fromName.Value);

            // Set the recipient's email address
            mail.To.Add(recipientEmail.Value);

            // Set the subject and body of the email
            mail.Subject = subject.Value;
            mail.Body = body.Value;

            // Set the SMTP client properties
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail.Value, senderPassword.Value) as ICredentialsByHost;
            smtpClient.EnableSsl = true;

            // Send the email
            smtpClient.Send(mail);

            Debug.Log("Email sent successfully.");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to send email: " + e.Message);
        }
    }

    /*private string FormatBody(string value)
    {
        string[] splitString = value.Split('\n');

        string newBody = String.Empty;

        foreach (String s in splitString)
        {
            newBody += s;
            newBody += Environment.NewLine;
        }

        return newBody;
    }*/
}