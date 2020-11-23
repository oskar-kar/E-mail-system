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

        public override string GetDescription()
        {
            return "Jesli chcesz dodac nowego uzytkownika wprowadz n, jesli chcesz sie zalogowac napisz l\n";
        }
        public override string GenerateResponse(string message)
        {
            message = message.Trim('\0', '\r', '\n');
            if (message.Equals("")) return "";
            switch (state)
            {
                case LoginState.UNVERIFIED:
                    if (message.Contains("l")) state = LoginState.WANTS_TO_LOGIN;
                    else if (message.Contains("n")) state = LoginState.WANTS_TO_CREATE_USER;
                    else return "Nieprawidlowowa komenda\n";
                    return "Podaj login i haslo rozdzielajac je dwukropkiem\n";
                case LoginState.WANTS_TO_CREATE_USER:
                    {
                        string[] login_data = message.Split(':');
                        if (login_data.Length != 2) return "nieprawidlowe dane rejestracyjne\n";
                        if (db.AddUser(login_data[0], login_data[1]))
                        {
                            state = LoginState.LOGGED;
                            return "Utworzono nowego uzytkownika i zalogowano sie. \n";
                        }
                        else
                        {
                            state = LoginState.UNVERIFIED;
                            return "Nie utworzono nowego uzytkownika, uzytkownik o podanym loginie już istnieje.\n";
                        }
                    }
                    break;
                case LoginState.WANTS_TO_LOGIN:
                    {
                        string[] login_data = message.Split(':');
                        if (login_data.Length != 2) return "nieprawidlowe dane logowania\n";
                        if (db.AuthenticateUser(login_data[0], login_data[1]))
                        {
                            state = LoginState.LOGGED;
                            return "Pomyslnie zalogowano.\n";
                        }
                        else
                        {
                            state = LoginState.UNVERIFIED;
                            return "Nieprawidlowy login lub haslo.\n";
                        }
                    }
                    break;
                case LoginState.LOGGED:
                    {
                        return "juz jestes zalogowany\n";
                    }
                default:
                    return "cos sie popsulo\n";
            }
        }
    }
}
