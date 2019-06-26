
//Inicio VerificarMayusActivo
//Verifica si el Bloq Mayús se encuentra activo, muestra o oculta la alerta
//input= Campo
function VerificarMayusActivo(Pcampo) {
    var _blnActivo = IndicadorMayuscula(Pcampo); //Metodo que verifica si se encuentra activo el Bloq Mayus. Se encuentra en el archivo GT.js
    if (_blnActivo) {
        document.getElementById("BloqMayusIcono").style.visibility = 'visible';
        document.getElementById("BloqMayusTexto").style.visibility = 'visible';
    } else {
        document.getElementById("BloqMayusIcono").style.visibility = 'hidden';
        document.getElementById("BloqMayusTexto").style.visibility = 'hidden';
    }

    if (Pcampo.keyCode == 13) {
        Iniciar();
    }
}
// Fin VerificarMayusActivo

//Iniciar sesion
function Iniciar() {
    var _usuario = document.getElementById("txtUsuario").value;
    var _contrasena = document.getElementById("txtContrasena").value;

    if (_usuario == null || _usuario.trim() == "") {
        MostrarPNotify("Error", "", "Debe ingresar el usuario.");
    } else if (_contrasena == null || _contrasena.trim() == "") {
        MostrarPNotify("Error", "", "Debe ingresar la contraseña.");
    } else {
        var _objDatos = {};
        _objDatos.Usuario = _usuario;
        _objDatos.Clave = _contrasena;
        var _actionURL = "/Inicio/Login";

        BloquearPagina();
        $.post(_actionURL, _objDatos, function (_resultado) {
            DesbloquearPagina();
            if (_resultado != null) {
                if (_resultado.Mensaje != null) {
                    if (_resultado.TipoAlerta == 'Error') {
                        MostrarPNotify("Error", "", _resultado.Mensaje);
                    } else if (_resultado.TipoAlerta == 'Informativo') {
                        MostrarPNotify("Informativo", "", _resultado.Mensaje);
                    } else if (_resultado.TipoAlerta == 'Correcto') {
                        MostrarPNotify("Correcto", "", _resultado.Mensaje);
                    }
                } else {
                    window.location = "/Inicio/Index";
                }
            }
        })
    }
}