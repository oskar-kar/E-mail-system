using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaBD;

namespace KlasaSerwera
{
    public class LoginProtocol : ComunicationProtocol
    {
        private DB db = new DB();
        private LoginState state = LoginState.UNVERIFIED;
        private string login = "";
        public override string GetDescription()
        {
            return "Jesli chcesz dodac nowego uzytkownika wprowadz n, jesli chcesz sie zalogowac napisz l\n";
        }
        public override ProtocolResponse GenerateResponse(string message)
        {
            message = message.Trim('\0', '\r', '\n', ' ');
            if (message.Equals("")) return new ProtocolResponse("");
            switch (state)
            {
                case LoginState.UNVERIFIED:
                    if (message.Contains("l")) state = LoginState.WANTS_TO_LOGIN;
                    else if (message.Contains("n")) state = LoginState.WANTS_TO_CREATE_USER;
                    else return new ProtocolResponse("Nieprawidlowowa komenda\n");
                    return new ProtocolResponse("Podaj login i haslo rozdzielajac je dwukropkiem\n");
                case LoginState.WANTS_TO_CREATE_USER:
                    {
                        string[] login_data = message.Split(':');
                        if (login_data.Length != 2 || message.Length < 3) return new ProtocolResponse("Nieprawidlowe dane rejestracyjne.\n");
                        if (db.AddUser(login_data[0], login_data[1]))
                        {
                            state = LoginState.LOGGED;
                            this.login = login_data[0];
                            return new ProtocolResponse("Utworzono nowego uzytkownika i zalogowano sie. \nPo zalogowaniu masz dostepna opcje zmiany hasla. " +
                                "Jesli chcesz z niej skorzystac wprowadz c.", login_data[0]);
                        }
                        else
                        {
                            state = LoginState.UNVERIFIED;
                            return new ProtocolResponse("Nie utworzono nowego uzytkownika, uzytkownik o podanym loginie juz istnieje.\n");
                        }
                    }
                case LoginState.WANTS_TO_LOGIN:
                    {
                        string[] login_data = message.Split(':');
                        if (login_data.Length != 2 || message.Length < 3) return new ProtocolResponse("Nieprawidlowe dane logowania.\n");
                        if (db.AuthenticateUser(login_data[0], login_data[1]))
                        {
                            state = LoginState.LOGGED;
                            this.login = login_data[0];
                            return new ProtocolResponse("Pomyslnie zalogowano. \nPo zalogowaniu masz dostepna opcje zmiany hasla. " +
                                "Jesli chcesz z niej skorzystac wprowadz c.", login_data[0]);
                        }
                        else
                        {
                            state = LoginState.UNVERIFIED;
                            return new ProtocolResponse("Nieprawidlowy login lub haslo.\n");
                        }
                    }
                case LoginState.LOGGED:
                    {
                        if (message.Contains("l")) return new ProtocolResponse("Juz jestes zalogowany.\n", login);
                        else if (message.Contains("c")) state = LoginState.WANTS_TO_CHANGE_PASS;
                        else return new ProtocolResponse("Nieprawidlowowa komenda\n");
                        return new ProtocolResponse("Wprowadz nowe haslo: \n");
                    }
                case LoginState.WANTS_TO_CHANGE_PASS:
                    {
                        if (db.ChangePassword(login, message))
                        {
                            state = LoginState.LOGGED;
                            return new ProtocolResponse("Twoje haslo zostalo zmienione.\n", login);
                        }
                        else
                        {
                            state = LoginState.LOGGED;
                            return new ProtocolResponse("Twoje haslo nie zostalo zmienione.\n", login);
                        }
                    }
                default:
                    return new ProtocolResponse("Cos sie popsulo.\n");
            }
        }
    }
}
