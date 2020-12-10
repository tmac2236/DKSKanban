if (!jQuery) { throw new Error("isRock framework requires jQuery.") }

//call ASP.NET PageMethod
function CallPageMethod(methodName, para, onSuccess, onFail) {
    //PageMethod��������array�A�Y�K�S���Ѽ�
    if (para == null) para = {};
    //�p�G�S��onSuccess�A�N�Τ��ت�
    if (onSuccess == undefined) {
        onSuccess = _CallPageMethod_Success;
    }
    //�p�G�S��onFail �A�N�Τ��ت�
    if (onFail == undefined) {
        onFail = _CallPageMethod_Fail;
    }
    //get URL
    var loc = window.location.href;
    loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "default.aspx" : loc
    if (loc.indexOf('#') != -1) { loc = loc.substr(0, loc.indexOf('#')); }
    if (loc.indexOf('?') != -1) { loc = loc.substr(0, loc.indexOf('?')); }
    //ajax call
    $.ajax({
        type: "POST",
        url: loc + "/" + methodName,
        data: JSON.stringify(para),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //on success
        success: function (response) {
            onSuccess(response.d)
        },
        //on fail
        failure: function (response) {
            onFail(response);
        }
    }).fail(function (response) {
        if (response.status == 299) { //����e�ݪ��ۭq�q���~�A��responseJSON
            var ex = { 'responseJSON': { 'Message': response.responseText } };
            onFail(ex);
        }
        else {
            onFail(response);
        }
    });
}

//�w�]���\Method
function _CallPageMethod_Success(result) {
    console.log('_CallPageMethod_Success Success return : ' + result, result);
    return result.data;
    //alert('ExecuteCommand Success.');
}

//�w�]����Method
function _CallPageMethod_Fail(ex) {
    console.log('_CallPageMethod_Fail error : ' + ex.responseJSON.Message, ex);
    alert("error : " + ex.responseJSON.Message);
}

//call WebAPI Method
function ExecuteAPI(catalog, method, para, success, fail) {
    $.ajax({
        url: "/api/" + catalog + "/" + method,
        type: "post",
        contentType: 'application/json',
        data: JSON.stringify(para),
        success: function (apiResult) {
            if (!success) {
                _ExecuteAPIonSuccess(apiResult);
            }
            else {
                success(apiResult);
            }
        },
        error: function (ex) {
            if (!fail) {
                _ExecuteAPIonError(ex);
            }
            else {
                fail(ex);
            }
        }
    })
}

//�w�]���\Method
function _ExecuteAPIonSuccess(apiResult) {
    if (apiResult.isSuccess) {
        alert("���\");
    }
    else {
        alert("���� : " + apiResult.Message);
    }
}

//�w�]����Method
function _ExecuteAPIonError(ex) {
    alert("���ѡA�Ч޳N���d��ex���� : " + ex);
}