// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.querySelector("#modalAdd form").addEventListener("submit", async (e) => {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);

    const response = await fetch(form.action, {
        method: "POST",
        body: formData
    });

    const result = await response.json();

    if (result.success) {
        const modal = bootstrap.Modal.getInstance(document.querySelector("#modalAdd"));
        modal.hide();

        location.reload();
    } else {
        document.querySelector("#modalAdd .modal-content").innerHTML = await response.text();
    }
});

document.getElementById('modalAdd').addEventListener('hidden.bs.modal', function () {
    const inputs = this.querySelectorAll('input, select');
    inputs.forEach(input => input.value = '');
});

document.addEventListener("DOMContentLoaded", () => {
    const especialidadeSelect = document.getElementById("especialidade");

    let data = [];
    fetch('/Profissional/GetEspecialidades')
        .then(response => response.json())
        .then(responseData => {
            data = responseData;

            responseData.forEach(especialidade => {
                const option = document.createElement("option");
                option.value = especialidade.nome;
                option.textContent = especialidade.nome;
                especialidadeSelect.appendChild(option);
            });
        })
        .catch(error => console.error('Erro ao carregar especialidades:', error));

    especialidadeSelect.addEventListener("change", () => {
        const especialidadeSelecionada = data.find(s => s.nome === especialidadeSelect.value);
        document.getElementById("tipoDocumento").value = especialidadeSelecionada?.tipoDocumento || "";
    });

    document.getElementById("btnSalvarProfissional").addEventListener("click", () => {
        const form = document.getElementById("formAddProfissional");
        if (form.checkValidity()) {
            const formData = new FormData(form);
            const data = Object.fromEntries(formData.entries());

            fetch("/Profissional/Create", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            })
                .then(response => {
                    if (response.ok) {
                        alert("Profissional cadastrado com sucesso!");
                        location.reload();
                    } else {
                        alert("Erro ao cadastrar profissional.");
                    }
                })
                .catch(error => console.error("Erro:", error));
        } else {
            form.reportValidity();
        }
    });
});

function filtrar() {
    var especialidadeSelecionada = document.getElementById("filtroEspecialidade").value;

    var linhasTabela = document.querySelectorAll("table tbody tr");

    linhasTabela.forEach(function (linha) {
        var especialidade = linha.querySelector("td:nth-child(3)").textContent.trim(); 

        if (especialidadeSelecionada === "" || especialidade === especialidadeSelecionada) {
            linha.style.display = ""; 
        } else {
            linha.style.display = "none";
        }
    });
}

$(document).ready(function () {
    $(".btn-edit").on("click", function () {
        var button = $(event.relatedTarget);
        
        var modalId = $(this).data("target");
        $(modalId).modal("show");
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const modalExcluir = document.getElementById('modalExcluir');
    const deleteForm = document.getElementById('deleteForm');
    const deleteIdInput = document.getElementById('deleteId');
    const deleteButton = document.getElementById('deleteButton');
    const loadingSpinner = document.getElementById('loadingSpinner');

    modalExcluir.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const profissionalId = button.getAttribute('data-id');
        deleteIdInput.value = profissionalId;  
        deleteForm.action = `/Home/Delete`;  

        loadingSpinner.style.display = 'none';
        deleteButton.disabled = false; 
    });

    deleteForm.addEventListener('submit', function (e) {
        e.preventDefault(); 

        loadingSpinner.style.display = 'block';
        deleteButton.disabled = true;  

        setTimeout(function () {
            deleteForm.submit();  
        }, 1500);  
    });
});