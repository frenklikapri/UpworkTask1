$(document).ready(() => {
    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
})

function showToaster(text, error = false) {
    Toastify({
        duration: 3000,
        text: text,
        gravity: "top",
        position: 'right',
        backgroundColor: error ? "#E74C3C" : "#18BC9C",
    }).showToast();
}

function showSwalConfirm(title, body, confirmCallback) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-danger',
            cancelButton: 'btn btn-primary ml-2'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: title,
        text: body,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Delete'
    }).then((result) => {
        if (result.isConfirmed) {
            confirmCallback();
        }
    })
}