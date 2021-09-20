var ValidaExclusao = function (id, evento) {
    if (confirm("Confirma a exclusão dos dados?")) {
        return true
    }
    else {
        evento.preventDefault();
        return false;
    }
};