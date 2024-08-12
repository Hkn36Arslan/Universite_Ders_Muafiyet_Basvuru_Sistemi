document.addEventListener("DOMContentLoaded", function () {
    var kullaniciButton = document.querySelector("#kullaniciButton");
    var basvuruButton = document.querySelector("#basvuruButton");
    var ekleButton = document.querySelector("#ekleButton");
    var editButtons = document.querySelectorAll(".editButton");
    var kayitForm = document.querySelector("#kayitForm");
    var editForm = document.querySelector("#editForm");
    var kullaniciPanel = document.querySelector("#kullaniciPanel");
    var basvuruPanel = document.querySelector("#basvuruPanel");
    var kayitFormPanel = document.querySelector(".kayitFormPanel");
    var editFormPanel = document.querySelector(".editFormPanel");
    var kullaniciTable = document.querySelector(".kullaniciTable");
    var kullaniciPanelClose = document.querySelector("#kullaniciPanel-close");
    var kayitFormPanelClose = document.querySelector("#kayitFormPanel-close");
    var editFormPanelClose = document.querySelector("#editFormPanel-close");
    var basvuruPanelClose = document.querySelector("#basvuruPanel-close");
    var filtreSelect = document.getElementById('filtreSelect');

    kullaniciButton.addEventListener("click", function () {
        
        if (kayitFormPanel.style.display === "block" || editFormPanel.style.display === "block") {
            alert("Lütfen formu doldurun veya kapatın.");
        } else {
            // Sonra diğer panelleri görünür/gizli hale getirin
            kullaniciPanel.style.display = "block";
            basvuruPanel.style.display = "none";
            kayitFormPanel.style.display = "none";
            editFormPanel.style.display = "none";
        }
    });
    
    basvuruButton.addEventListener("click", function () {
        if (kayitFormPanel.style.display === "block" || editFormPanel.style.display === "block") {
            alert("Lütfen formu doldurun veya kapatın.");
        } else {
            // Sonra diğer panelleri görünür/gizli hale getirin
            kullaniciPanel.style.display = "none";
            basvuruPanel.style.display = "block";
            kayitFormPanel.style.display = "none";
            editFormPanel.style.display = "none";
        }
    });

    kullaniciPanelClose.addEventListener("click", function () {
        kullaniciPanel.style.display = "none";
    });

    ekleButton.addEventListener("click", function () {
        var inputFields = kayitFormPanel.querySelectorAll("input");
        kullaniciTable.style.display = "none";
        kayitFormPanel.style.display = "block";
        editFormPanel.style.display = "none";
        kullaniciPanelClose.style.display = "none";

        inputFields.forEach(function (input) {
            input.value = "";
        });
    });

    editButtons.forEach(function (button) {
        button.addEventListener("click", function () {
            var row = button.closest("tr");
            var adSoyad = row.cells[0].textContent;
            var mail = row.cells[1].textContent;
            var bolumBilgisi = row.cells[2].textContent;

            editForm.querySelector("input[name='AdSoyad']").value = adSoyad;
            editForm.querySelector("input[name='Mail']").value = mail;
            editForm.querySelector("input[name='BolumBilgisi']").value = bolumBilgisi;

            kullaniciTable.style.display = "none";
            kayitFormPanel.style.display = "none";
            editFormPanel.style.display = "block";
            kullaniciPanelClose.style.display = "none";
        });
    });

    kayitForm.addEventListener("submit", function (event) {
        kullaniciTable.style.display = "block";
        kayitFormPanel.style.display = "none";
        kullaniciPanelClose.style.display = "block";
    });

    editForm.addEventListener("submit", function (event) {
        kullaniciTable.style.display = "block";
        editFormPanel.style.display = "none";
        kullaniciPanelClose.style.display = "block";
    });

    kayitFormPanelClose.addEventListener("click", function () {
        kullaniciTable.style.display = "block";
        kayitFormPanel.style.display = "none";
        kullaniciPanelClose.style.display = "block";
    });

    editFormPanelClose.addEventListener("click", function () {
        kullaniciTable.style.display = "block";
        editFormPanel.style.display = "none";
        kullaniciPanelClose.style.display = "block";
    });

    basvuruPanelClose.addEventListener("click", function () {
        basvuruPanel.style.display = "none";
    });

    filtreSelect.addEventListener('change', function () {
        var filterValue = this.value.toLowerCase();
        var rows = document.querySelectorAll('#basvuruTable tbody tr');
        rows.forEach(function (row) {
            var department = row.cells[2].textContent.toLowerCase();
            row.style.display = (filterValue === "" || department.includes(filterValue)) ? "" : "none";
        });
    });
    var basvuruTable = document.querySelector("#basvuruTable");

    basvuruTable.addEventListener("click", function (event) {
        // Sadece PDF bağlantılarına tıklamaları dinlemek için
        if (event.target.matches(".fa-file-pdf")) {
        var tr = event.target.closest("tr");

        // Tıklanan öğeye göre ilgili veri niteliğini ayarla
        if (event.target.id === "Basvuru") {
            tr.dataset.basvuruAcildi = "true";
            event.target.style.color = "black";
        } else if (event.target.id === "Transkript") {
            event.target.style.color = "black";
            tr.dataset.transkriptAcildi = "true";
        } else if (event.target.id === "DersDokum") {
            event.target.style.color = "black";
            tr.dataset.dersDokumAcildi = "true";
        }

        // Tüm bağlantıların tıklanıp tıklanmadığını kontrol et
        checkAllOpened(tr);
        }
    });

    function checkAllOpened(tr) {
        if (
        tr.dataset.basvuruAcildi === "true" &&
        tr.dataset.transkriptAcildi === "true" &&
        tr.dataset.dersDokumAcildi === "true"
        ) {
        tr.style.backgroundColor = "#24D330";
        tr.style.color = "white";
        
        tr.querySelectorAll(".fa-file-pdf").forEach(function(pdfIcon) {
            pdfIcon.style.color = "white";
        });
        }
    }
});
