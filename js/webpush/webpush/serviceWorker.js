console.log("Service worker started.");

self.addEventListener('push', function(event) {
    event.waitUntil(
            registration.showNotification('A push message  arrived:', {
                        body: event.data ? event.data.text() : 'no payload',
                        icon: 'icon.png'
                    })
        );
});
