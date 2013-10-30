function goPage(url) {
    var form = document.getElementById('mainForm');
    form.action = url;
    form.submit();
}

function showLoadDialog() {
    document.getElementById('loadDialog').style.display = 'block';
    $('#pageContainer :input').attr('readonly', true);
}

function closeLoadDialog() {
    $('#loadDialog').css('display', 'none');
    $('#pageContainer :input').removeAttr('readonly');
}

$(function () {
    $("#lnkMaxStats").click(function () { goPage('/Character/MaxStats'); });

    $("#lnkSave").click(function () { goPage('/Character/Save'); });

    $('#lnkLoad').click(function () { showLoadDialog(); });
    $('#btnLoadCancel').click(function () { closeLoadDialog(); });
    $('#btnLoadOk').click(function () { closeLoadDialog(); });
});