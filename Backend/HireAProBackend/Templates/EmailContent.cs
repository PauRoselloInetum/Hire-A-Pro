﻿namespace HireAProBackend.Templates
{
    public class EmailContent
    {
        public string VerifySubject { get; set; } = "Verifica tu cuenta";
        public string VerifyBody { get; set; }
        public string WelcomeSubject { get; set; } = "¡Te damos la bienvenida a Hire a pro!";
        public string WelcomeBody { get; set; }
        public string ChangePassSubject { get; set; } = "Solicitud de regeneración de contraseña";
        public string ChangePassBody { get; set; }
        public string VerifyAgainSubject { get; set; } = "IMPORTANTE: Verifica tu cuenta";
        public string VerifyAgainBody { get; set; }

        public string WelBody(string user)
        {
            WelcomeBody = @"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Bienvenida</title>
    <style>
        body {
            font-family: Verdana, sans-serif, serif, EmojiFont;
        }
        @media screen and (max-width: 400px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        @media screen and (max-width: 700px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        .btn {
            background-color: #00ffab;
            color: black;
            padding: 10px 20px;
            font-size: smaller;
            text-decoration: none;
            border-radius: 10px;
        }
    </style>
</head>
<body style='margin:0;padding:0;word-spacing:normal;background-color:#e2e2e2;font-family: Verdana, sans-serif, serif, EmojiFont;'>
    <table class='container' style='margin-left:auto; margin-right:auto; width:100%;border:none; border-spacing:0;'>
        <tr>
            <td align='center'>
                <table style='border:none; border-spacing:0; background-color:white; width:90%; max-width:600px; text-align:center; height:100%; max-height:100%;'>
                    <tr>
                        <td style='background-color:#3d9970; padding-top:80px;'></td>
                    </tr>
                    <tr>
                        <td style='padding:40px 30px 0px 30px; text-align:center; color:#2f2f2f;'>
                            <h1>¡Te damos la bienvenida a Hire a pro!</h1>
                        </td>
                    </tr>
                    <tr>
                        <td><h2 style='color:#333'>Nos alegra tenerte con nosotros</h2></td>
                    </tr>
                    <tr>
                        <td style='padding:0px 40px 40px 30px; text-align:center; font-size:large; color:#333;'>
                            " + user + @", te animamos a explorar un poco
                            <br><br>
                            ¡Encuentra los mejores profesionales!
                            <br><br><br>
                            <b style='color:#333;'>El equipo de Hire a pro</b>
                        </td>
                    </tr>
                    <tr style='background-color:#3d9970;'>
                        <td style='padding:30px 30px 30px 30px; text-align:center; font-size:smaller; color:white;' align='center'>
                            <p style='color:white;'>¿No has sido tú? <a href='' style='color:white; font-size:smaller;'>Contacta con nosotros</a></p>
                        </td>
                    </tr>
                    <tr style='background-color:#2f2f2f;'>
                        <td colspan='2'>
                            <table width='100%'>
                                <tr>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:left;'>&copy;2024</td>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:right;'>[Nombre empresa]</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
";
            return WelcomeBody;
        }
        public string PassBody(string user, string link)
        {
            ChangePassBody = @"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Regenerar contraseña</title>
    <style>
        body {
            font-family: Verdana, sans-serif, serif, EmojiFont;
        }
        @media screen and (max-width: 400px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        @media screen and (max-width: 700px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        .btn {
            background-color: #333;
            color: white;
            padding: 10px 20px;
            font-size: smaller;
            text-decoration: none;
            border-radius: 10px;
        }
    </style>
</head>
<body style='margin:0;padding:0;word-spacing:normal;background-color:#e2e2e2;font-family: Verdana, sans-serif, serif, EmojiFont;'>
    <table class='container' style='margin-left:auto; margin-right:auto; width:100%;border:none; border-spacing:0;'>
        <tr>
            <td align='center'>
                <table style='border:none; border-spacing:0; background-color:white; width:90%; max-width:600px; text-align:center; height:100%; max-height:100%;'>
                    <tr>
                        <td style='background-color:#3d9970;padding-top:80px;'></td>
                    </tr>
                    <tr>
                        <td style='padding:40px 30px 0px 30px; text-align:center; color:#2f2f2f;'>
                            <h1>" + user + @"<br>Has solicitado regenerar tu contrase&ntilde;a</h1>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding:0px 40px 40px 30px; text-align:center; font-size:large;'>
                            Para generar una nueva contrase&ntilde;a, haz click en el siguiente enlace:
                            <br><br>
                            <a href='" + link + @"' class='btn' style='color:white;'> Regenerar mi contrase&ntilde;a</a>
                            <br><br><br>
                            <b style='color:#333;'>El equipo de Hire a pro</b>
                        </td>
                    </tr>
                    <tr style='background-color:#3d9970;'>
                        <td style='padding:30px 30px 30px 30px; text-align:center; font-size:smaller; color:white;' align='center'>
                            <p>¿No has sido tú? <a href='' style='color:white;font-size:smaller;'>Contacta con nosotros</a></p>
                        </td>
                    </tr>
                    <tr style='background-color:#2f2f2f;'>
                        <td colspan='2'>
                            <table width='100%'>
                                <tr>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:left;'>&copy;2024</td>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:right;'>[Nombre empresa]</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
            return ChangePassBody;
        }
        public string VerBody(string user, string link)
        {
            VerifyBody = @"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Verificación</title>
    <style>
        body {
            font-family: Verdana, sans-serif, serif, EmojiFont;
        }
        @media screen and (max-width: 400px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        @media screen and (max-width: 700px) {
            .container {
                width: 100% !important;
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        .btn {
            background-color: #333;
            color: white;
            padding: 10px 20px;
            font-size: smaller;
            text-decoration: none;
            border-radius: 10px;
        }
    </style>
</head>
<body style='margin:0;padding:0;word-spacing:normal;background-color:#e2e2e2; font-family: Verdana, sans-serif, serif, EmojiFont;'>
    <table class='container' style='margin-left:auto; margin-right:auto; width:100%;border:none; border-spacing:0;'>
        <tr>
            <td align='center'>
                <table style='border:none; border-spacing:0; background-color:white; width:90%; max-width:600px; text-align:center; height:100%; max-height:100%;'>
                    <tr>
                        <td style='background-color:#3d9970;padding-top:80px;'></td>
                    </tr>
                    <tr>
                        <td style='padding:40px 30px 0px 30px;text-align:center;color:#2f2f2f;'>
                            <h1>" + user + @"<br>Verifica tu cuenta</h1>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding:0px 40px 40px 30px;text-align:center; font-size:large;'>
                            Has indicado que quieres registrarte en Hire a Pro, para confirmar, ve al siguiente enlace:
                            <br><br>
                            <a href='" + link + @"' class='btn' style='color:white;'>Verificar</a>
                            <br><br><br>
                            <b style='color:#333;'>El equipo de Hire a Pro</b>
                        </td>
                    </tr>
                    <tr style='background-color:#3d9970;'>
                        <td style='padding:30px 30px 30px 30px;text-align:center; font-size:smaller; color:white;' align='center'>
                            <p>¿No has sido tú? <a href='' style='color:white;font-size:smaller;'>Contacta con nosotros</a></p>
                        </td>
                    </tr>
                    <tr style='background-color:#2f2f2f;'>
                        <td colspan='2'>
                            <table width='100%'>
                                <tr>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:left;'>&copy;2024</td>
                                    <td style='padding:20px 30px 30px 30px; color:white; font-size:x-small; text-align:right;'>HireAPro</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
            return VerifyBody;
        }
        public string Ver2Body(string user, string link, string date)
        {
            VerifyAgainBody = @"<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Verificación</title>
    <style>
        body {
            font-family: Verdana, sans-serif, serif, EmojiFont;
        }
        @media screen and (max-width: 400px) {
            .container {
                width: 100% !important;  
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        @media screen and (max-width: 700px) {
            .container {
                width: 100% !important;  
                height: 100%;
            }
            .imagen {
                max-width: 100%;
            }
        }
        .btn {
            background-color: #333;
            color: white;
            padding: 10px 20px;
            font-size: smaller;
            text-decoration: none;
            border-radius: 10px;
        }
        .alert {
            background-color: rgb(250, 200, 200);
            color: brown;
            margin: 0 auto;
            width: 80%;
            padding: 10px;
            border-radius: 10px;
        }
    </style>
</head>
<body style='margin:0;padding:0;word-spacing:normal;background-color:#e2e2e2; font-family: Verdana, sans-serif, serif, EmojiFont;'></body>
    <table class='container' style='margin-left: auto; margin-right: auto; width: 100%;border: none; border-spacing: 0;'>
    <tr>
        <td align='center'>
            <table style='border:none;border-spacing: 0; background-color: white; width: 90%; max-width:600px; text-align: center;height: 100%; max-height: 100%;'>
                <tr>
                    <td style='background-color: #3d9970;padding-top: 80px;'></td>
                </tr>
                <tr>
                    <td style='padding:40px 30px 0px 30px;text-align: center;color:#2f2f2f'><h1>" + user + @"<br>verifica tu cuenta</h1></td>
                </tr>
                <tr>
                    <td style='padding:0px 40px 40px 30px;text-align: center; font-size: large;'>
                        Hace 7 días decidiste registrarte en HireAPro, pero aún no has verificado tu correo.<br><br>
                        Para verificar que quieres registrarte, haz click en el siguiente enlace:
                        <br><br>
                        <a href='" + link + @"' class='btn' style='color:white'>Verificar</a>
                    </td>
                </tr>
                <tr>
                    <td><p class='alert'>Si en 3 días no verificas tu cuenta, tendrás que volver a registrarte.<br>
                    Puedes verificar la cuenta hasta el " + date + @"</p></td>
                </tr>
                <tr>
                    <td style='padding:40px 40px 40px 30px;text-align: center;font-size:large'> 
                        <b style='color: #333;'>El equipo de Hire a Pro</b>  
                    </td> 
                </tr>
                <tr style='background-color:#3d9970 ;'>
                    <td style='padding:30px 30px 30px 30px;text-align: center; font-size: smaller;color: white;' align='center'>
                        <p>¿No has sido tú? <a href='' style='color: white;font-size: smaller;'>Contacta con nosotros</a></p>
                    </td>
                </tr>
                <tr style='background-color: #2f2f2f;'>
                    <td colspan='2'>
                        <table width='100%'>
                            <tr>
                                <td style='padding:20px 30px 30px 30px; color: white; font-size: x-small; text-align: left;'>&copy;2024</td>
                                <td style='padding:20px 30px 30px 30px; color: white; font-size: x-small; text-align: right;'>HireAPro</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table> 
        </td>
    </tr>
</table> 
</body>
</html>";
            return VerifyAgainBody;
        }
    }
}