
export function loadGoogleTranslate() {
    return new Promise((resolve, reject) => {
        if (window.google?.translate?.TranslateElement) {
            init();
            resolve();
            return;
        }

        const script = document.createElement('script');
        script.src = '//translate.google.com/translate_a/element.js?cb=googleTranslateCallback';
        script.async = true;
        script.onerror = reject;

        window.googleTranslateCallback = () => {
            init();
            resolve();
        };

        document.head.appendChild(script);

        function init() {
            new google.translate.TranslateElement({
                pageLanguage: 'es',
                includedLanguages: 'es,en,pt,it,fr,de,zh-CN,zh-TW',
                layout: google.translate.TranslateElement.InlineLayout.SIMPLE
            }, 'google_translate_element');
        }
    });
}
