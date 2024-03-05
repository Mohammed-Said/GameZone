document.getElementById('Cover').addEventListener('change', (e) => {
    document.querySelector('.img-preview').src = window.URL.createObjectURL(e.currentTarget.files[0]);
    document.querySelector('.img-preview').classList.remove("d-none");
})