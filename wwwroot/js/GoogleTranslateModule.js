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
                includedLanguages: 'es,zh-CN,zh-TW,en,pt,it,fr,de',
                layout: google.translate.TranslateElement.InlineLayout.SIMPLE,
            }, 'google_translate_element');
        }
    });
}
