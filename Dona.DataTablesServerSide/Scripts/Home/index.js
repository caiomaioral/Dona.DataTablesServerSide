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
                    "mData": "DtAniversario"
                },
                {
                    "sName": "Emprego.Nome",
                    "mData": "EmpregoNome"
                },
                {
                    "sName": "Emprego.Salario",
                    "mData": "EmpregoSalario"
                }
            ]
    });

})