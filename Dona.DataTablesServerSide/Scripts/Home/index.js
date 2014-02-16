$(function () {

    $("#tblPessoas").dataTable({
        "bServerSide": true,
        "sAjaxSource": "Home/BuscaAssincrona",
        "bProcessing": true,
        "aoColumns": 
            [
                {
                    "sName": "Nome",
                    "mData": "Nome"
                },
                {
                    "sName": "DtAniversario",
                    "mData": "DtAniversario",
                    "mRender" : function(val, type)
                    {
                        var bDay = new Date(parseInt(val.substr(6)));
                        return Globalize.format(bDay, "dd/MM/yyyy");
                    }
                },
                {
                    "sName": "Emprego.Nome",
                    "mData": "EmpregoNome"
                },
                {
                    "sName": "Emprego.Salario",
                    "mData": "EmpregoSalario",
                    "mRender": function(val)
                    {
                        return Globalize.format(val, "C");
                    }
                }
            ]
    });

})