function ValidateEmail(element) {
    el = $("#" + element)
    if (el.val().indexOf("@") == -1 || el.val().length < 4) {
        let msg = "O email não é válido.";
        el.addClass();
        return msg;
    }
    return true;
}

function ValidatePassword(element) {
    el = $("#" + element)
    if (el.val().length < 6) {
        let msg = "A senha requer no mínimo 6 caracteres.";
        return msg;
    }
    return true;
}

function ValidatePasswords(element,element2) {
    el = $("#" + element)
    el = $("#" + element2)

    if (el.val().length < 6) {
        let msg = "A senha requer no mínimo 6 caracteres.";
        return msg;
    }
    return true;           
}

let usernameEl = $('#username');
let username = usernameEl.val();
$('#username').on('mouseup', function() {
    $
});