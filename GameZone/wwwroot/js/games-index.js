document.querySelectorAll(".delete-btn").forEach(b => b
    .addEventListener('click', (e) => {
        let btn = e.currentTarget;

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Are you sure that you need to delete this game?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`/Games/Delete/${btn.dataset.id}`, {
                    method: "Delete",
                }).then(res => {
                    if (res.ok) {   
                        swal.fire(
                            'Deleted!',
                            'Game has been deleted.',
                            'success'
                        );
                        btn.closest("tr").remove();
                    }
                    else
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                })
            }
        });
        //console.log(btn.dataset.id);
        //$.ajax(
        //    {
        //        url: `/Games/Delete/${btn.dataset.id}`,
        //        method: "Delete",
        //        success: () => alert("Success"),
        //        error: () => alert("error")
        //    }
        //)

        //ajax

        //let xhr = new XMLHttpRequest();
        //xhr.open("Delete", `/Games/Delete/${btn.dataset.id}`);
        //xhr.onload = function () {
        //        if (xhr.status===200)
        //            alert("success");
        //        else
        //            alert("error", res.statusText);
        //}
        //xhr.send();

        //Fetech

    }))

