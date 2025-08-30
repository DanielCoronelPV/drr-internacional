window.sendEmail = async function (formData) {
    try {
        // Inicializa EmailJS (solo una vez)
        //if (!window.emailjsInitialized) {
            emailjs.init("E4UNOHpNXV0V8q5WJ");
            window.emailjsInitialized = true;
        //}

        //console.log("✉️ Datos recibidos para enviar:", formData);

        const response = await emailjs.send("service_kf19ddt", "template_g0mb4t8", {
            from_name: formData.FullName,
            from_email: formData.Email,
            phone: formData.Phone,
            //reason: formData.Reason,
            //modules: formData.Modules?.join(', ') || '',
            message: formData.Message
        });

        //console.log("✅ Correo enviado con éxito:", response);
        alert("✅ Correo enviado correctamente.");
    } catch (error) {
        console.error("❌ Error al enviar correo:", error);
        alert("❌ Ocurrió un error al enviar el correo.");
    }
};

window.getSelectedModules = (dotNetHelper) => {
    const select = document.querySelector('select[multiple]');
    if (!select) return;

    const selected = Array.from(select.selectedOptions).map(opt => opt.value);
    dotNetHelper.invokeMethodAsync("SetSelectedModules", selected);
};