document.addEventListener("DOMContentLoaded", function() {
    
    var basvuruButton = document.querySelector("#basvuruButton");
    

   
    basvuruButton.addEventListener("click", function() {

        var basvuruPanel = document.querySelector("#basvuruPanel");

        basvuruPanel.style.display = "block";
        
    });
 
    document.querySelector("#basvuruPanel-close").addEventListener("click", function() {
        
        var basvuruPanel = document.querySelector("#basvuruPanel");

        basvuruPanel.style.display = "none";
          
    });
    
    var basvuruTable = document.querySelector('#basvuruTable');

    basvuruTable.addEventListener('click', function (event) {
        // Sadece PDF bağlantılarına tıklamaları dinlemek için
        if (event.target.matches('.fa-file-pdf')) {
            var tr = event.target.closest('tr');
            
            // Tıklanan öğeye göre ilgili veri niteliğini ayarla
            if (event.target.id === 'Basvuru') {
                tr.dataset.basvuruAcildi = "true";
                event.target.style.color = 'black'; 
            } else if (event.target.id === 'Transkript') {
                event.target.style.color = 'black'; 
                tr.dataset.transkriptAcildi = "true";
            } else if (event.target.id === 'DersDokum') {
                event.target.style.color = 'black'; 
                tr.dataset.dersDokumAcildi = "true";
            }

            // Tüm bağlantıların tıklanıp tıklanmadığını kontrol et
            checkAllOpened(tr);
        }
    });

    function checkAllOpened(tr) {
        if (tr.dataset.basvuruAcildi === "true" && tr.dataset.transkriptAcildi === "true" && tr.dataset.dersDokumAcildi === "true") {
            tr.style.backgroundColor = '#24D330';
            tr.style.color = 'white';
            
            tr.querySelectorAll(".fa-file-pdf").forEach(function(pdfIcon) {
                pdfIcon.style.color = "white";
            });
        }
    }

});

