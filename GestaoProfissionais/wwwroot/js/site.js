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

document.addEventListener("DOMContentLoaded", () => {
    //const especialidades = [
    //    { nome: "Cardiologia", tipoDocumento: "CRM" },
    //    { nome: "Nutricionista Clínico", tipoDocumento: "CRN" },
    //    { nome: "Fisioterapia Ortopédica", tipoDocumento: "CREFITO" },
    //    // Adicione todas as especialidades aqui
    //];
    const especialidadeSelect = document.getElementById("especialidade");

    if (!especialidadeSelect) {
        console.error("Elemento especialidadeSelect não encontrado!");
        return;
    }

    fetch('/Professional/GetEspecialidades')
        .then(response => {
            if (!response.ok) {
                throw new Error(`Erro ao carregar especialidades: ${response.statusText}`);
            }
            return response.json();
        })
        .then(data => {
            //const especialidadeSelect = document.getElementById("especialidade");
            //especialidadeSelect.innerHTML = '<option value="">Selecione a especialidade</option>';

            data.forEach(especialidade => {
                const option = document.createElement("option");
                option.value = especialidade.nome;
                option.textContent = especialidade.nome;
                especialidadeSelect.appendChild(option);
            });
        })
        .catch(error => console.error('Erro ao carregar especialidades:', error));

    //const especialidadeSelect = document.getElementById("especialidade");
    //especialidades.forEach(especialidade => {
    //    const option = document.createElement("option");
    //    option.value = especialidade.nome;
    //    option.textContent = especialidade.nome;
    //    especialidadeSelect.appendChild(option);
    //});

    especialidadeSelect.addEventListener("change", () => {
        const especialidadeSelecionada = data.find(s => s.nome === especialidadeSelect.value);
        document.getElementById("tipoDocumento").value = especialidadeSelecionada?.tipoDocumento || "";
    });

    document.getElementById("btnSalvarProfissional").addEventListener("click", () => {
        const form = document.getElementById("formAddProfissional");
        if (form.checkValidity()) {
            const formData = new FormData(form);
            const data = Object.fromEntries(formData.entries());

            fetch("/Professional/Create", {
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

document.getElementById('modalAdd').addEventListener('hidden.bs.modal', function () {
    const inputs = this.querySelectorAll('input, select');
    inputs.forEach(input => input.value = '');
});