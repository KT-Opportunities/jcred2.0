function Export(filename, companyName, RegistrationNumber, searchType) {
    var con2 = document.getElementsByClassName('con2')
    var left_col = document.getElementsByClassName('left_col')
    var seaMore = document.getElementsByClassName('seaMore')
    var seaMoreDeedsOffice = document.getElementsByClassName('seaMoreDeedsOffice')
    var not = document.getElementsByClassName('not')

    con2[0].style.flexDirection = "column";
    left_col[0].style.visibility = "collapse";
    var SeaInfo = document.getElementsByClassName('SeaInfo');
    var PerInfo = document.getElementsByClassName('PerInfo');
    var HomeInfo = document.getElementsByClassName('HomeInfo');
    var TeleHis = document.getElementsByClassName('TeleHis');
    var EmpHis = document.getElementsByClassName('EmpHis');
    if (PerInfo.length != 0) {
        PerInfo[0].style.marginBottom = "20px";
    }

    /* var table = document.getElementById('table');*/

    if (not.length != 0) {
        not[0].style.visibility = "visible";
        not[0].style.display = "";
    }

    if (seaMoreDeedsOffice.length != 0) {
        for (var j = 0; j < seaMoreDeedsOffice.length; j++) {
            seaMoreDeedsOffice[j].style.visibility = "hidden";
        }
    }

    if (seaMore.length != 0) {
        for (var i = 0; i < seaMore.length; i++) {
            seaMore[i].style.visibility = "hidden";
        }
    }

    //NCR Notification
    /* $(".seaRes").hide();*///< --- was working
    $("#minusNot").hide();
    $("#plusNot").hide();
    /*$(".not").hide();*/ //<---was working
    //Person Information
    $(".PerInfo").show();
    $("#minusPerInfo").show();
    $("#plusPerInfo").hide();
    $("#PITU").show();
    //Home Affairs Information
    $(".HomeInfo").show();
    $("#minusHomeInfo").show();
    $("#plusHomeInfo").hide();
    $("#HAITU").show();
    //PropertyInformation
    $("#PROPI").show();
    //CompanyInformation
    $("#COMI").show();

    var element = document.getElementById('content');

    html2pdf()
        .from(element)
        .set({
            margin: [70, 1, 80, 1],//<--On Trial....
            //margin: [80, 1, 160, 1],/<---- Works
            filename: filename,
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: {
                dpi: 196, scale: 4, scrollX: 0, scrollY: 0, backgroundColor: '#FFF', letterRendering: true, useCORS: true
            },//<----Try this out
            jsPDF: { unit: 'pt', format: 'letter', orientation: 'portrait' },
            //*pagebreak: { after:'.PerInfo' }
        })
        .toPdf().get('pdf').then(function (pdf) {
            var totalPages = pdf.internal.getNumberOfPages();
            for (let i = 1; i <= totalPages; i++) {
                pdf.setPage(i);
                pdf.setFontSize(10);
                pdf.setTextColor(150);
                pdf.text('Page ' + i + ' of ' + totalPages, pdf.internal.pageSize.getWidth() - 100, pdf.internal.pageSize.getHeight() - 10);//<----Try this out
            }
            pdf.setPage(1);
            /*var img = new Image();*/
            /* img.src = 'http://localhost:24871/Content/img/logo.png'*/
            pdf.addImage('http://localhost:24871/Content/img/logo.png', 'png', 25, 0, 200, 100)
            //Add companyName
            pdf.setFontSize(20);
            pdf.setTextColor(150);
            pdf.text(companyName, 230, 40);
            //Add RegistrationNumber/PersonID
            pdf.setFontSize(14);
            pdf.setTextColor(150);
            pdf.text(RegistrationNumber, 230, 80);
            //Add searchType
            pdf.setFontSize(17);
            pdf.setTextColor(150);
            pdf.text(searchType, 230, 60);
            //Jcred Website link
            pdf.setFontSize(10);
            pdf.setTextColor(150);
            pdf.text("Website: https://www.jcred.co.za", 450, 80);
        }).save();

    setTimeout(function () {
        con2[0].style.flexDirection = "row";

        if (seaMore.length != 0) {
            for (var i = 0; i < seaMore.length; i++) {
                seaMore[i].style.visibility = "visible";
            }
        }

        if (seaMoreDeedsOffice.length != 0) {
            for (var j = 0; j < seaMoreDeedsOffice.length; j++) {
                seaMoreDeedsOffice[j].style.visibility = "visible";
            }
        }

        if (not.length != 0) {
            not[0].style.display = "none";
        }

        left_col[0].style.visibility = "visible"
        if (not.length != 0) {
            not[0].style.visibility = "visible";
        }

        //PerInfo[0].style.marginBottom = "10px";

        //NCR Notification
        $(".seaRes").show();
        $("#minusNot").hide();
        $("#plusNot").show();
        $(".not").hide();
        //Person Information
        $("#minusPerInfo").hide();
        $("#plusPerInfo").show();
        $(".PerInfo").hide();
        $("#PITU").toggle();
        //Home Affairs Information
        $("#minusHomeInfo").hide();
        $("#plusHomeInfo").show();
        $(".HomeInfo").hide();
        $("#HAITU").hide();
        //PropertyInformation
        $("#PROPI").hide();
        //CompanyInformation
        $("#COMI").hide();
    }, 1000);
}

//CompScan
$("#PI").click(function () {
    $("#PIT").toggle();
});
$("#HAI").click(function () {
    $("#HAIT").toggle();
});
$("#CI").click(function () {
    $("#CIT").toggle();
});

$("#HI").click(function () {
    $("#HIT").toggle();
});

$("#add").click(function () {
    $("#addT").toggle();
});

$("#tel").click(function () {
    $("#telT").toggle();
});
$("#CONI").click(function () {
    $("#CONIT").toggle();
})

$("#em").click(function () {
    $("#emT").toggle();
});

//TransUnion
$("#PIU").click(function () {
    $("#PITU").toggle();
});
$("#HAIU").click(function () {
    $("#HAITU").toggle();
});
$("#CIU").click(function () {
    $("#CITU").toggle();
});

$("#HIU").click(function () {
    $("#HITU").toggle();
});

$("#addU").click(function () {
    $("#addTU").toggle();
});

$("#telU").click(function () {
    $("#telTU").toggle();
});

$("#emU").click(function () {
    $("#emTU").toggle();
});

//XDS
$("#PIX").click(function () {
    $("#PITX").toggle();
});
$("#HAIX").click(function () {
    $("#HAITX").toggle();
});
$("#CIX").click(function () {
    $("#CITX").toggle();
});

$("#HIX").click(function () {
    $("#HITX").toggle();
});

$("#addX").click(function () {
    $("#addTX").toggle();
});

$("#telX").click(function () {
    $("#telTX").toggle();
});

$("#emX").click(function () {
    $("#emTX").toggle();
});

//VeriCred
$("#PIV").click(function () {
    $("#PITV").toggle();
});
$("#HAIV").click(function () {
    $("#HAITV").toggle();
});
$("#CIV").click(function () {
    $("#CITV").toggle();
});

$("#HIV").click(function () {
    $("#HITV").toggle();
});

$("#addV").click(function () {
    $("#addTV").toggle();
});

$("#telV").click(function () {
    $("#telTV").toggle();
});

$("#emV").click(function () {
    $("#emTV").toggle();
});

$(document).ready(function () {
    $(".not").hide();
    $("#minusNot").hide();

    $('#plusNot').on('click', function () {
        $(".not").show();
        $("#minusNot").show();
        $("#plusNot").hide();
    });

    $('#minusNot').on('click', function () {
        $("#minusNot").hide();
        $("#plusNot").show();
        $(".not").hide();
    });

    $("#minusSeaInfo").hide();
    $(".SeaInfo").hide();

    $('#plusSeaInfo').on('click', function () {
        $(".SeaInfo").show();
        $("#minusSeaInfo").show();
        $("#plusSeaInfo").hide();
    });

    $('#minusSeaInfo').on('click', function () {
        $("#minusSeaInfo").hide();
        $("#plusSeaInfo").show();
        $(".SeaInfo").hide();
    });

    $("#minusPerInfo").hide();
    $(".PerInfo").hide();

    $('#plusPerInfo').on('click', function () {
        $(".PerInfo").show();
        $("#minusPerInfo").show();
        $("#plusPerInfo").hide();
    });

    $('#minusPerInfo').on('click', function () {
        $("#minusPerInfo").hide();
        $("#plusPerInfo").show();
        $(".PerInfo").hide();
    });

    $("#minusHomeInfo").hide();
    $(".HomeInfo").hide();

    $('#plusHomeInfo').on('click', function () {
        $(".HomeInfo").show();
        $("#minusHomeInfo").show();
        $("#plusHomeInfo").hide();
    });

    $('#minusHomeInfo').on('click', function () {
        $("#minusHomeInfo").hide();
        $("#plusHomeInfo").show();
        $(".HomeInfo").hide();
    });

    $("#minusTeleHis").hide();
    $(".TeleHis").hide();

    $('#plusTeleHis').on('click', function () {
        $(".TeleHis").show();
        $("#minusTeleHis").show();
        $("#plusTeleHis").hide();
    });

    $('#minusTeleHis').on('click', function () {
        $("#minusTeleHis").hide();
        $("#plusTeleHis").show();
        $(".TeleHis").hide();
    });

    $("#minusEmpHis").hide();
    $(".EmpHis").hide();

    $('#plusEmpHis').on('click', function () {
        $(".EmpHis").show();
        $("#minusEmpHis").show();
        $("#plusEmpHis").hide();
    });

    $('#minusEmpHis').on('click', function () {
        $("#minusEmpHis").hide();
        $("#plusEmpHis").show();
        $(".EmpHis").hide();
    });
});