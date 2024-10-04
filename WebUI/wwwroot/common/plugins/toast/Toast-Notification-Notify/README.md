# Notify
A light-weight yet customizable toast plugin for jQuery

## Usage

Include `jquery.notify.js` and `jquery.notify.css` and of course `jquery` to your page

```
<link rel="stylesheet" href="jquery.notify.css" />

<script src="jquery.js"></script>
<script src="jquery.notify.js"></script>
```

__JS__

```js
$.notify();
```

## Available options

```js
wrapper: 'body',
message: 'Your request submitted successfuly!',
// success, info, error, warn
type: 'success',
// 1: top-left, 2: top-center, 3: top-right
// 4: mid-left, 5: mid-right
// 6: bottom-left, 7: bottom-center, 8: bottom-right
position: 1,
dir: 'ltr',
autoClose: true,
duration: 4000,
onOpen: null,
onClose: null
```

## License

[MIT](https://github.com/digitalify/notify/blob/master/LICENSE)
