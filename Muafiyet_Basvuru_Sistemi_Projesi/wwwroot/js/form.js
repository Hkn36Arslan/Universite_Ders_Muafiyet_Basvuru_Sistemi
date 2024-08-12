/* ! Tarih */
window.onload = function () {
    var simdikiTarih = new Date();
    var gun = simdikiTarih.getDate();
    var ay = simdikiTarih.getMonth() + 1;
    var yil = simdikiTarih.getFullYear();
    var tarih = (gun < 10 ? "0" + gun : gun) + "/" + (ay < 10 ? "0" + ay : ay) + "/" + yil;
    document.getElementById("date").innerText = tarih;
};

/* ! T.C. kimlik no kontrol */
var inputElement = document.getElementById("tc_no");

inputElement.addEventListener("input", function () {
    var value = this.value;

    if (value.length !== 11 || !isNumeric(value)) {
        this.setCustomValidity("TC Kimlik numarası 11 haneli olmalı ve sadece rakamlardan oluşmalıdır.");
    } else {
        // Hata mesajını temizle
        this.setCustomValidity("");
    }
});

// Girilen değerin sadece rakamlardan oluşup oluşmadığını kontrol etmek için fonksiyon
function isNumeric(str) {
    return /^\d+$/.test(str);
}

/* ! Ders Tablosuna yeni satır ekleme */
document.getElementById("ekleButton").addEventListener("click", function (event) {
    event.preventDefault(); // Sayfanın yenilenmesini engelle

    // Yeni bir satır oluştur
    var derslerBody = document.getElementById("derslerBody");
    var newRow = document.createElement("tr");

    // Dersler için gerekli input tiplerini tanımla
    var inputTypes = [
        "text",
        "number",
        "number",
        "text",
        "number",  
        "number",
        "text",
    ];

    for (var i = 0; i < 7; i++) { 
        var cell = document.createElement("td");
        // Diğer sütunlar için input alanlarını ekle
        var input = document.createElement("input");
        input.setAttribute("type", inputTypes[i]);
        input.setAttribute("class", "inputDers");
        // Her input için benzersiz id oluştur
        input.setAttribute("name", "dersInput_" + (derslerBody.childElementCount + 1) + "_" + (i + 1));
        cell.appendChild(input);
        newRow.appendChild(cell);
    }

    // Silme butonu için ek sütun oluştur
    var deleteCell = document.createElement("td");
    deleteCell.style.border="none";
    var deleteButton = document.createElement("button");
    deleteButton.className = "fas fa-trash";
    deleteButton.style.backgroundColor="red";
    deleteButton.style.border="none";
    deleteButton.style.borderRadius="3px";
    deleteButton.style.color="white";
    deleteButton.style.textAlign = "center"; // Metin hizalaması
    deleteButton.addEventListener("click", function () {
        // Silme butonuna tıklandığında ilgili satırı kaldır
        derslerBody.removeChild(newRow);
    });
    
    deleteButton.addEventListener("mouseover", function () {
        deleteButton.className = "fas fa-trash-alt"; 
    });
    
    deleteButton.addEventListener("mouseout", function () {
        deleteButton.className = "fas fa-trash"; 
    });
    deleteCell.appendChild(deleteButton);
    newRow.appendChild(deleteCell);

    derslerBody.appendChild(newRow);
});

var form = document.querySelector('form');
form.addEventListener('submit', function () {
    
    var formData = new FormData(form); // Form verilerini al

    var bolumBaskanligiValue = document.getElementById("bolum_baskanligi").value;
    var adisoyadiValue = " : " + "  " + document.getElementById("adi_soyadi").value;
    var tc_noValue = " : " + " " + document.getElementById("tc_no").value;
    var ogrenci_noValue = " : " + "  " + document.getElementById("ogrenci_no").value;
    var telefonValue = " : " + "  " + document.getElementById("telefon").value;
    var epostaValue = " : " + "  " + document.getElementById("eposta").value;
    var kayit_sekliValue = " : " + "  " + document.getElementById("kayit_sekli").value;
    var geldigi_UniValue = " : " + "  " + document.getElementById("geldigi_Uni").value;
    var geldigi_fakulteValue = " : " + "  " + document.getElementById("geldigi_fakulte").value;
    var GeldigiBolumValue = " : " + "  " + document.getElementById("GeldigiBolum").value;

    formData.append("bolum_baskanligi", bolumBaskanligiValue);
    formData.append("adi_soyadi", adisoyadiValue);
    formData.append("tc_no", tc_noValue);
    formData.append("ogrenci_no", ogrenci_noValue);
    formData.append("telefon", telefonValue);
    formData.append("eposta", epostaValue);
    formData.append("kayit_sekli", kayit_sekliValue);
    formData.append("geldigi_Uni", geldigi_UniValue);
    formData.append("geldigi_fakulte", geldigi_fakulteValue);
    formData.append("GeldigiBolum", GeldigiBolumValue);

    var urlParams = new URLSearchParams(); // URL parametreleri oluştur

    for (var pair of formData.entries()) {
        // Her bir form verisini URL parametreleri olarak ekle
        urlParams.append(pair[0], pair[1]);
    }

    // Ders bilgilerini al
    var dersBilgileri = [];
    var dersSatirlari = document.querySelectorAll("#derslerBody tr");

    dersSatirlari.forEach(function (satir, index) {
        var ders = {};

        // Satırdaki tüm input alanlarını seç
        var inputAlanlari = satir.querySelectorAll("input");

        inputAlanlari.forEach(function (input, i) {
            // Input alanının adını ve değerini ders bilgileri objesine ekle
            ders["dersInput_" + (index + 1) + "_" + (i + 1)] = input.value;
            
        });

        // Ders bilgilerini diziye ekle
        dersBilgileri.push(ders);
    });

    // Ders bilgilerini URL parametrelerine ekle
    dersBilgileri.forEach(function (ders) {
        for (var key in ders) {
            urlParams.append(key, ders[key]);
        }
    });

    // İkinci sayfaya geçiş yap
    window.open("BasvuruFormuPdf?" + urlParams.toString(), "_blank");

    form.submit();
});

