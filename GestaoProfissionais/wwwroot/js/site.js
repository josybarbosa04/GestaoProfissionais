// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.querySelector("#createModal form").addEventListener("submit", async (e) => {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);

    const response = await fetch(form.action, {
        method: "POST",
        body: formData
    });

    const result = await response.json();

    if (result.success) {
        const modal = bootstrap.Modal.getInstance(document.querySelector("#createModal"));
        modal.hide();

        location.reload();
    } else {
        document.querySelector("#createModal .modal-content").innerHTML = await response.text();
    }
});
