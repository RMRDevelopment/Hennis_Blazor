window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success", { timeout: 5000 });
    }

    if (type === "error") {
        toastr.error(message, "Failed", { timeout: 5000 });
    }
}

window.ShowSweetAlert = (type, message) => {
    if (type === "success") {
        Swal.fire({
            icon: 'success',
            title: 'Success Notification',
            text: message
        });
    }

    if (type === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Error Notification',
            text: message
        });
    }
}